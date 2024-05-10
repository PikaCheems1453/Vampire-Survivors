using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyState
{
    public EnemyWalkState(Enemy _enemyBase, EnemyStateMachine stateMachine, string enemyAnimationBoolName) : base(_enemyBase, stateMachine, enemyAnimationBoolName)
    {
        
    }

    public override void Update()
    {
        base.Update();
        if (Mathf.Abs(enemyBase.transform.position.y - enemyBase.target.position.y) < 0.5 &&
            Mathf.Abs(enemyBase.transform.position.x - enemyBase.target.position.x) < 1)
        {
            enemyBase.enemyStateMachine.ChangeState(enemyBase.EnemyAttackState);
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

}
