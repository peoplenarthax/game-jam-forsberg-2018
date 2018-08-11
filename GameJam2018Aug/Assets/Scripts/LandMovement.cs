using UnityEngine;
public class LandMovement : Movement
{

    public override void Move(Rigidbody2D rigidBody)
    {
        rigidBody.velocity = new Vector3(GetXAxis() * SpeedMultiplier, rigidBody.velocity.y, 0);
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && rigidBody.velocity.y == 0)
        {
            rigidBody.velocity = Vector2.up * VerticalMultiplier;
        }

        Debug.Log(rigidBody.velocity.x);
        Debug.Log(rigidBody.velocity.y);

        if (rigidBody.velocity.y > MAX_SPEED)
        {
            rigidBody.velocity = Vector3.ClampMagnitude(
                rigidBody.velocity,
                MAX_SPEED
           );
            Debug.Log(rigidBody.velocity);
        }
    }
}
