using UnityEngine;

public abstract class Movement : MonoBehaviour 
{
    public Controller2D controller;


    public abstract void transitionInto();
    public abstract void Move();
}