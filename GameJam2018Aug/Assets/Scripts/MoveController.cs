using UnityEngine;

public class MoveController : MonoBehaviour {
    public float x_velocity;
    public float y_velocity;

    public Rigidbody2D myRigidbody2D;
    public Movement currentMovement;
    public WaterMovement waterMovement;
    public LandMovement landMovement;
    // Use this for initialization
    void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        currentMovement = GetComponent<LandMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMovement.Move(myRigidbody2D);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "water")
        {
            currentMovement = GetComponent<WaterMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "water")
        {
            currentMovement = GetComponent<LandMovement>();
        }
    }

}
