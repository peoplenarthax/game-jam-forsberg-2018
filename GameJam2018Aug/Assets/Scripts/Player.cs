using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public int lifes;
    int currentLife;
    Controller2D controller;
    Movement currentMovementController;
    Transform life1;
    Transform life2;
    Transform life3;
    public Animator anim;
    public SpriteRenderer spriterenderer;
    public SpriteRenderer lifeSprite;
    private Transform pSystem;

    void Start()
    {
        currentLife = lifes;
        pSystem = transform.Find("Particles");
        pSystem.gameObject.SetActive(false);
        currentMovementController = GetComponent<LandMovement>();
        anim = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        life1 = transform.Find("Life1");
        life2 = transform.Find("Life2");
        life3 = transform.Find("Life3");

    }

    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.RightArrow))
        if (Input.GetAxis("Horizontal") > 0)
        {
            spriterenderer.flipX = false;

        }

        // Ugly workaround to fix lifes fast
        if (currentLife == 2) {
            life3.gameObject.SetActive(false);
        }

        if (currentLife == 1)
        {
            life2.gameObject.SetActive(false);
        }

        if (currentLife == 0)
        {
            life1.gameObject.SetActive(false);
        }
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        if (Input.GetAxis("Horizontal") < 0)
        {
            spriterenderer.flipX = true;

        }
        currentMovementController.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            currentLife--;
        }
        if (collision.tag == "water")
        {
            pSystem.gameObject.SetActive(true);
            anim.SetBool("inWater", true);
            currentMovementController = GetComponent<WaterMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "water")
        {
            pSystem.gameObject.SetActive(false);
            anim.SetBool("inWater", false);
            currentMovementController = GetComponent<LandMovement>();
            currentMovementController.transitionInto();
        }
    }
}