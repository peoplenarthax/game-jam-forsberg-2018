using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    Controller2D controller;
    Movement currentMovementController;
    public Animator anim;
    public SpriteRenderer spriterenderer;
    private Transform pSystem;

    void Start()
    {
        pSystem = transform.Find("Particles");
        pSystem.gameObject.SetActive(false);
        currentMovementController = GetComponent<LandMovement>();
        anim = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.RightArrow))
        if (Input.GetAxis("Horizontal") > 0)
        {
            spriterenderer.flipX = false;

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