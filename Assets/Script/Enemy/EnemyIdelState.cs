using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdelState : EnemyState
{
    private float speed;
    
    public EnemyIdelState(Enemy _enemyBase, EnemyStateMachine stateMachine, string enemyAnimationBoolName) : base(_enemyBase, stateMachine, enemyAnimationBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        EnemyStateTime = enemyBase.IdelTime;
        speed = enemyBase.GetMoveSpeed();
    }

    public override void Update()
    {
        base.Update();
        if (EnemyStateTime <= 0)
        {
            enemyBase.enemyStateMachine.ChangeState(enemyBase.EnemyWalkState);
        }
        if (enemyBase.damageEnemy.health <= 0)
        {
            enemyBase.enemyStateMachine.ChangeState(enemyBase.EnemyDeathState);
        }

        if (enemyBase.damageEnemy.isHit)
        {
            enemyBase.enemyStateMachine.ChangeState(enemyBase.EnemyHitState);
        }
    }

    public override void Exite()
    {
        base.Exite();
        enemyBase.SetMoveSpeed(speed);
    }
}
