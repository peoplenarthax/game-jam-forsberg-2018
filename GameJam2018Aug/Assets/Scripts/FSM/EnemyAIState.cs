using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAIState : MonoBehaviour {

    public abstract void OnStateEnter(EnemyAI enemyAI);
    public abstract void OnStateUpdate(EnemyAI enemyAI);
    public abstract void OnStateExit(EnemyAI enemyAI);

}
