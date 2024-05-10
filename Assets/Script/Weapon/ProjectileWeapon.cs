using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public EnemyDamager damager;
    public Projectile projectile;
    public float shotCounter;
    public float weaponRange;
    public LayerMask whatIsEnemy;


    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if(statsUpdated == true)
        {
            statsUpdated = false;

            SetStats();
        }

        shotCounter -=Time.deltaTime;
        if(shotCounter <= 0)
        {
            shotCounter = stats[weaponLevel].timeBetweenAttacks;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange * stats[weaponLevel].range, whatIsEnemy);
            if(enemies.Length > 0)
            {
                for(int i = 0; i < stats[weaponLevel].amount; i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0,enemies.Length)].transform.position;
                    //计算目标方向
                    Vector3 direction = targetPosition - transform.position;
                    //计算向量与横轴夹角的弧度，并转为角度
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle -= 90;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    var Obj = Instantiate(projectile, transform.position, projectile.transform.rotation);
                    Obj.transform.gameObject.SetActive(true);
                }
                SFXManager.instance.PlaySFXPitched(6);
            }
        }

    }

    void SetStats()
    {
        damager.damageAmount = stats[weaponLevel].damage;
        damager.lifeTime = stats[weaponLevel].duration;

        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        shotCounter = 0f;

        projectile.moveSpeed = stats[weaponLevel].speed;
    }
}
