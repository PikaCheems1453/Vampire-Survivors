using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float IdelTime = 0.5f;
    public Transform target { get; set; }
    [Header("Move Info")]
    [SerializeField]private float moveSpeed = 2f;
    public float damage = 10f;
    public bool isDeath;

    public Rigidbody2D enemyRigidbody2D{ get; private set; }
    public Animator enemyAnimator{ get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public EnemyStateMachine enemyStateMachine { get; private set; }
    public DamageEnemy damageEnemy { get; private set; }
    public CircleCollider2D circleCollider2D { get; private set; }
    public EnemyIdelState EnemyIdelState { get; private set; }
    public EnemyWalkState EnemyWalkState { get; private set; }
    public EnemyAttackState EnemyAttackState { get; private set; }
    public EnemyDeathState EnemyDeathState { get; private set; }
    public EnemyHitState EnemyHitState { get; private set; }
    
    private void Awake()
    {
        enemyStateMachine = new EnemyStateMachine();
        EnemyIdelState = new EnemyIdelState(this, enemyStateMachine, "Idel");
        EnemyWalkState = new EnemyWalkState(this, enemyStateMachine, "Walk");
        EnemyAttackState = new EnemyAttackState(this, enemyStateMachine, "Attack");
        EnemyDeathState = new EnemyDeathState(this, enemyStateMachine, "Death");
        EnemyHitState = new EnemyHitState(this, enemyStateMachine, "Hit");
        isDeath = false;
    }

    private void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        damageEnemy = GetComponent<DamageEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        enemyStateMachine.Initialize(EnemyIdelState);
        target = PlayerHealthController.instance.transform;
    }

    private void Update()
    {
        if(target==null) return;
        enemyStateMachine.CurrentState.Update();
        enemyRigidbody2D.velocity = (target.position - transform.position).normalized * moveSpeed;
        spriteRenderer.flipX = enemyRigidbody2D.velocity.x < 0;
        if (isDeath)
        {
            GameObjectPool.instance.ReturnToPool(GameObjectPool.instance.GetNeedPool(gameObject), gameObject);
        }
    }

    private void FixedUpdate()
    {
        enemyStateMachine.CurrentState.FixedUpdate();
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
