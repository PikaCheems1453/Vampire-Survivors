using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyState
{
    public EnemyDeathState(Enemy _enemyBase, EnemyStateMachine stateMachine, string enemyAnimationBoolName) : base(_enemyBase, stateMachine, enemyAnimationBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        enemyBase.circleCollider2D.enabled = false;
        EnemyStateTime = 1f;
        enemyBase.enemyRigidbody2D.velocity = Vector2.zero;
        enemyBase.SetMoveSpeed(0);
    }

    public override void Update()
    {
        base.Update();
        if (EnemyStateTime <= 0)
        {
            enemyBase.isDeath = true;
        }
    }
}
