using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected EnemyStateMachine enemyStateMachine_;
    protected Enemy enemyBase;
    protected Rigidbody2D enemyRigidbody2D;
    private string _enemyAnimationBoolName;
    protected float EnemyStateTime;

    public EnemyState(Enemy _enemyBase, EnemyStateMachine stateMachine, string enemyAnimationBoolName)
    { 
        enemyBase = _enemyBase;
        enemyStateMachine_ = stateMachine;
        _enemyAnimationBoolName = enemyAnimationBoolName;
    }

    public virtual void Enter()
    {
        enemyRigidbody2D = enemyBase.enemyRigidbody2D;
        enemyBase.enemyAnimator.SetBool(_enemyAnimationBoolName, true);
    }

    public virtual void Update()
    {
        if(EnemyStateTime>=0) EnemyStateTime -= Time.deltaTime;
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void Exite()
    {
        enemyRigidbody2D = null;
        enemyBase.enemyAnimator.SetBool(_enemyAnimationBoolName, false);
    }
}
