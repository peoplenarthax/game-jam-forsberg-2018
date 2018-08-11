using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public float SpeedMultiplier;
    public float VerticalMultiplier;

    public float x_velocity;
    public float y_velocity;
    public Rigidbody2D myRigidbody2D;


    public MovementState CurrentState;

    public LandState landState;
    public WaterState waterState;
    // Use this for initialization
    void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        landState = new LandState();
        waterState = new WaterState();
        CurrentState = landState;
	}

    // Update is called once per frame
    void Update()
    {
        CurrentState.Move(this);

    }


    float GetXAxis(){
        return (Input.GetAxisRaw("Horizontal"));
    }

    float GetYAxis(){
        return (Input.GetAxisRaw("Vertical"));
    }

    public abstract class MovementState{
        public abstract void Move(MoveController controller);
    }

    public class LandState:MovementState{
        public override void Move(MoveController controller)
        {
            controller.myRigidbody2D.velocity = new Vector3(controller.GetXAxis() * controller.SpeedMultiplier, controller.myRigidbody2D.velocity.y);
        }
    }

    public class JumpState : MovementState
    {
        
        public override void Move(MoveController controller)
        {
            controller.myRigidbody2D.velocity = new Vector3(controller.GetXAxis() * controller.SpeedMultiplier, controller.myRigidbody2D.velocity.y);
        }
    }


    public class WaterState : MovementState
    {
        public override void Move(MoveController controller)
        {
            controller.myRigidbody2D.velocity = new Vector3(controller.GetXAxis() * controller.SpeedMultiplier, controller.myRigidbody2D.velocity.y);
            controller.myRigidbody2D.AddForce(new Vector2(0, controller.GetYAxis() * controller.VerticalMultiplier));
        }
    }
        

}
