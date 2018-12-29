using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;

    float health;

    void Start()
    {
        health = maxHealth;
        GetComponentInChildren<HealthBar>().GiveCurrentHealth(health / maxHealth);
    }

    public virtual float DealDamage(float damage)
    {
        health -= damage;
        GetComponentInChildren<HealthBar>().GiveCurrentHealth(health / maxHealth);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        return 0f;
    }
}
