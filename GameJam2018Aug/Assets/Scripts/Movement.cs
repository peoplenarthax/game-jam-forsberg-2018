using UnityEngine;

public abstract class Movement : MonoBehaviour 
{
    public float SpeedMultiplier;
    public float VerticalMultiplier;
    public abstract void Move(Rigidbody2D rigidbody);

    public float GetXAxis()
    {
        return (Input.GetAxisRaw("Horizontal"));
    }

    public float GetYAxis()
    {
        return (Input.GetAxisRaw("Vertical"));
    }
}