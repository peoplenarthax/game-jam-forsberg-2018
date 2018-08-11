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
    }
}
