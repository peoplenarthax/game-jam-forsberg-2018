using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    Controller2D controller;
    Movement currentMovementController;
    public Animator anim;
    public SpriteRenderer spriterenderer;

    void Start()
    {
        currentMovementController = GetComponent<LandMovement>();
        anim = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

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
        currentMovementController.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "water")
        {
            anim.SetBool("inWater", true);
            currentMovementController = GetComponent<WaterMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "water")
        {
            anim.SetBool("inWater", false);
            currentMovementController = GetComponent<LandMovement>();
            currentMovementController.transitionInto();
        }
    }
}