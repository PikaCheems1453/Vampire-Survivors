using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 5;
    [HideInInspector]public float health;
    public int expToGive = 1;
    public float coinDropRate = .5f;
    public int coinValue = 1;
    public float knockBackTime = 0.2f;
    protected float knockBackCounter;
    public bool isHit;

    private void Awake()
    {
        health = MaxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter > 0)
        {
            if (!isHit)
            {
                isHit = true;
            }

            knockBackCounter -= Time.deltaTime;
        }
        else
        {
            isHit = false;
            knockBackCounter = -1;
        }
    }
    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        if(health <= 0)
        {
            ExperienceLevelController.instance.SpawnExp(transform.position,expToGive);

            if(Random.value <= coinDropRate)
            {
                CoinController.instance.DropCoin(transform.position, coinValue);
            }
            
            SFXManager.instance.PlaySFXPitched(0);
        }else
        {
            SFXManager.instance.PlaySFXPitched(1);
        }

        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);
    }
    
    public void TakeDamage(float damageToTake,bool shouldKnockback)
    {
        TakeDamage(damageToTake);
        if (shouldKnockback) {
            knockBackCounter = knockBackTime;
        }
    }
    
}
