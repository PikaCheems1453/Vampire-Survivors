using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private float _attackTimer = 0.3f;
    private float aTimer;
    private float speed;
    public EnemyAttackState(Enemy _enemyBase, EnemyStateMachine stateMachine, string enemyAnimationBoolName) : base(_enemyBase, stateMachine, enemyAnimationBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        aTimer = _attackTimer;
        EnemyStateTime = 0.4f;
        speed = enemyBase.GetMoveSpeed();
        enemyBase.SetMoveSpeed(0);
    }

    public override void Update()
    {
        base.Update();
        aTimer -= Time.deltaTime;
        if (aTimer <= 0)
        {
            PlayerHealthController.instance.TakeDamage(enemyBase.damage);
            aTimer = _attackTimer;
        }

        if (EnemyStateTime <= 0)
        {
            enemyBase.enemyStateMachine.ChangeState(enemyBase.EnemyIdelState);
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
