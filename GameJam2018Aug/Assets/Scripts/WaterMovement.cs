using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : Movement {
    float gravity;

    public float timeToJumpApex = .4f;
    public float jumpHeight;
    float moveSpeed = 15;
    public float sinkSpeedMax = 3;

    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    Vector3 velocity;
    float jumpVelocity;
    float velocityXSmoothing = 0;
    void Start()
    {
        controller = GetComponent<Controller2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    // Update is called once per frame
    public override void Move () {
        // Get Direction from arrows
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float targetVelocityX = moveDirection.x * moveSpeed;

        // Slow down velocity, using instead of rigidBody addForce
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpVelocity;
        }

        if (controller.collisions.above)
        {
            // Stop player if on ground or roof
            velocity.y = 0;
        }

        // Dont sink faster than the max
        if (velocity.y < -sinkSpeedMax)
        {
            velocity.y = -sinkSpeedMax;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public override void transitionInto()
    {
    }
}
