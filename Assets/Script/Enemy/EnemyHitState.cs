using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : EnemyState
{
    private float speed;
    public EnemyHitState(Enemy _enemyBase, EnemyStateMachine stateMachine, string enemyAnimationBoolName) : base(_enemyBase, stateMachine, enemyAnimationBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        speed = enemyBase.GetMoveSpeed();
        enemyBase.SetMoveSpeed(-enemyBase.GetMoveSpeed() * 2f);
    }

    public override void Update()
    {
        base.Update();
        if (enemyBase.damageEnemy.health <= 0)
        {
            enemyBase.enemyStateMachine.ChangeState(enemyBase.EnemyDeathState);
        }

        if (!enemyBase.damageEnemy.isHit)
        {
            enemyBase.SetMoveSpeed(speed);
            enemyBase.enemyStateMachine.ChangeState(enemyBase.EnemyIdelState);
        }
    }
}
