using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderState : EnemyAIState {


    public float WaitTimerFloat;
    public float WaitTimeBeforeMovingFloat;

    [Header ("Fields")]
    public float WaitTimeMax;
    public float WaitTimeMin;
    public float Radius;


    public void MoveToNewTarget()
    {
        Vector3 targetPos = Pathfinding.FindNextTargetInRadius(gameObject.transform.position, Radius, LayerMask.NameToLayer("Obstacle"), LayerMask.NameToLayer("Water"));
        //Debug.Log(controller.transform.name + targetPos);
        gameObject.GetComponent<EnemyMove>().WalkTo(targetPos);
    }

    public void ResetWaitTimer()
    {
        WaitTimerFloat = 0;
        WaitTimeBeforeMovingFloat = Random.value * (WaitTimeMax - WaitTimeMin) + WaitTimeMin;
    }


    public override void OnStateEnter(EnemyAI enemyAI)
    {
        ResetWaitTimer();
    }

    public override void OnStateUpdate(EnemyAI enemyAI)
    {
        if (!GetComponent<EnemyMove>().isMovingToTarget)
        {
            //if(!controller.GetFSMBool(IsLookingForTarget)){
            float WaitTimer = WaitTimerFloat + Time.deltaTime;
            if (WaitTimer > WaitTimeBeforeMovingFloat)
            {
                ResetWaitTimer();
                MoveToNewTarget();
            }
            else
            {
                WaitTimerFloat = WaitTimer;
            }

            //controller.SetFSMBool(IsLookingForTarget, true);
        }
    }

    public override void OnStateExit(EnemyAI enemyAI)
    {
    }
}
