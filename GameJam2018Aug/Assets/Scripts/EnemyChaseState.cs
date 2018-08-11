using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyAIState
{
    public GameObject ChaseTarget;
    public EnemyMove enemyMove;
    public float ChaseSpeed;

    public override void OnStateEnter(EnemyAI enemyAI)
    {
        enemyMove = GetComponent<EnemyMove>();
    }

    public override void OnStateExit(EnemyAI enemyAI)
    {
        enemyMove.Speed = enemyMove.DefaultSpeed;
    }

    public override void OnStateUpdate(EnemyAI enemyAI)
    {
        enemyMove.Speed = ChaseSpeed;
        enemyMove.WalkTo(ChaseTarget.transform);
    }
}
