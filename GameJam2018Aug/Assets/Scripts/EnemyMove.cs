using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float DefaultSpeed;
    public float Speed;
    public float TurningSpeed;

    public bool isWalking;
    public bool isTurning;
    public bool isMovingToTarget;

    private bool IsBlocked;

    public Transform Target;
    public Vector3 TargetPosition;
    public float TargetDetectRadius = 2f;
    public bool hasReachedTarget;
    bool isMovable;

    Animator animator;

    void Start()
    {
        Animator animator = GetComponent<Animator>();
        Speed = DefaultSpeed;
    }

    void Update()
    {


        if (isWalking)
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }

        if (isTurning)
        {

            // update direction each frame:
            Vector3 dir = TargetPosition - transform.position;
            // calculate desired rotation:
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            // Slerp to it over time:
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), TurningSpeed * Time.deltaTime);
        }

        if (isMovingToTarget)
        {
            if (Vector3.Distance(transform.position, TargetPosition) < TargetDetectRadius)
            {
                isMovingToTarget = false;
                Stop();
            }
        }

        if (IsBlocked)
        {
            StopWalking();
        }



    }

    public void Walk()
    {
        isWalking = true;
        if (animator != null){
            animator.SetBool("isWalking", true);   
        }
    }

    public void StopWalking()
    {
        isWalking = false;
        if (animator != null)
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void StopLookAt()
    {
        isTurning = false;
        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }
    }

    public void Stop()
    {
        StopWalking();
        isMovingToTarget = false;
        isTurning = false;
        if (animator != null)
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void WalkTo(Transform transform)
    {
        TargetPosition = transform.position;
        WalkTo(TargetPosition);
    }

    public void WalkTo(Vector3 pos)
    {
        TargetPosition = pos;
        Walk();
        isMovingToTarget = true;
        isTurning = true;
    }

    public void TurnTo(Transform transform)
    {
        TurnTo(transform.position);
    }

    public void TurnTo(Vector3 pos)
    {
        TargetPosition = pos;
        isTurning = true;
        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            IsBlocked = true;
            Stop();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            IsBlocked = false;
            Stop();
        }
    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(TargetPosition, 0.2f);
    }
}