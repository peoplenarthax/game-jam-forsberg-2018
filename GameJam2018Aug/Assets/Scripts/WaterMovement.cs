using UnityEngine;
public class WaterMovement : Movement {

    public override void Move(Rigidbody2D rigidBody)
    {
        rigidBody.velocity = new Vector3(GetXAxis() * SpeedMultiplier, rigidBody.velocity.y, 0);
        rigidBody.AddForce(new Vector2(0, GetYAxis() * VerticalMultiplier));

    }
}
