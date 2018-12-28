﻿using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;

    float health;

    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        GetComponentInChildren<HealthBar>().GiveCurrentHealth(health / maxHealth);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
