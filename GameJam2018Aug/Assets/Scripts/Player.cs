using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    Controller2D controller;
    Movement currentMovementController;

    void Start()
    {
        currentMovementController = GetComponent<LandMovement>();
    }

    void Update()
    {
        currentMovementController.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "water")
        {
            currentMovementController = GetComponent<WaterMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("EXITING");

        if (collision.tag == "water")
        {
            currentMovementController = GetComponent<LandMovement>();
            currentMovementController.transitionInto();
        }
    }
}