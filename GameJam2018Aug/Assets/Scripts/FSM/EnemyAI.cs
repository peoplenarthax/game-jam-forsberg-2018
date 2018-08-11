using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public EnemyAIState CurrentState;
    public bool IsAIActive;

	// Use this for initialization
	void Start () {
        CurrentState.OnStateEnter(this);
	}
	
	// Update is called once per frame
	void Update () {
        CurrentState.OnStateUpdate(this);
	}

    void ChangeState(EnemyAIState enemyAIState){
        CurrentState.OnStateExit(this);
        CurrentState = enemyAIState;
        enemyAIState.OnStateEnter(this);
    }
}
