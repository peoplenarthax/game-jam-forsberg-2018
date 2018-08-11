using UnityEngine;

public class MoveController : MonoBehaviour {
    public float x_velocity;
    public float y_velocity;

    public Rigidbody2D myRigidbody2D;
    public Movement currentMovement;
    public WaterMovement waterMovement;
    public LandMovement landMovement;
    public Animator anim;
    public SpriteRenderer spriterenderer;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        currentMovement = GetComponent<LandMovement>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriterenderer.flipX = false;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriterenderer.flipX = true;
            
        }
        currentMovement.Move(myRigidbody2D);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "water")
        {
            anim.SetBool("inWater",true);
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
