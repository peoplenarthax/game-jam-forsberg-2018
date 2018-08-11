using UnityEngine;
public class LandMovement : Movement
{
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 15;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .1f;
    public float recoverTime = 50000f;

    float timeToWallUnstick;
    float timeToRecoverFromWater;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;
    bool fromWater = false;

    void Start()
    {
        timeToRecoverFromWater = 0;
        controller = GetComponent<Controller2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    public override void transitionInto()
    {
        if (timeToRecoverFromWater <= 0) {

            fromWater = true;
        }
    }

    public override void Move()
    {
        // Get Direction from arrows
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float verticalDir = Mathf.Sign(moveDirection.y);
        
        // Where is the wall
        int wallDirX = (controller.collisions.left) ? -1 : 1;
        
        float targetVelocityX = moveDirection.x * moveSpeed;
        // Slow down velocity, using instead of rigidBody addForce
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        bool wallSliding = false;
        if (timeToRecoverFromWater > 0)
        {

            // Removing from frame time
            Debug.Log(timeToRecoverFromWater);

            timeToRecoverFromWater -= Time.deltaTime;

        }
        // If collisions against wall (We match Walls Layer) do wall slide
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            // Control max speed
            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

     

            // Time our player can stick without sliding
            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (moveDirection.x != wallDirX && moveDirection.x != 0)
                {
                    // Removing from frame time
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }

        }

        if (controller.collisions.above || controller.collisions.below)
        {
            // Stop player if on ground or roof
            velocity.y = 0;
        }



        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (wallSliding)
            {
                // jump against same side
                if (wallDirX == moveDirection.x)
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                // get off the wall
                else if (moveDirection.x == 0)
                {
                    velocity.x = -wallDirX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                // Jump to the other side
                else
                {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            }
            if (controller.collisions.below)
            {
                velocity.y = jumpVelocity;
            }
        }

        Debug.Log(velocity.y);
        if (fromWater && timeToRecoverFromWater <= 0)
        {
            
            timeToRecoverFromWater = 2f;
            fromWater = false;
            velocity.y = jumpVelocity;
        }
        else {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
