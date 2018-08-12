using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite attackingSprite;
    public EnemyAIState CurrentState;
    public bool IsAIActive;
    EnemyChaseState enemyChaseState;
    EnemyWanderState enemyWanderState;
    SpriteRenderer childSprite;

    // Use this for initialization
    void Start()
    {
        enemyChaseState = GetComponent<EnemyChaseState>();
        enemyWanderState = GetComponent<EnemyWanderState>();
        childSprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        CurrentState = enemyWanderState;
        CurrentState.OnStateEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.OnStateUpdate(this);
    }

    void ChangeState(EnemyAIState enemyAIState)
    {
        CurrentState.OnStateExit(this);
        CurrentState = enemyAIState;
        enemyAIState.OnStateEnter(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) {
            childSprite.sprite = attackingSprite;
            ChangeState(enemyChaseState);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            childSprite.sprite = normalSprite;
            ChangeState(enemyWanderState);
        }
    }
}
