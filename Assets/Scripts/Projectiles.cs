using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float Speed;
    public float Damage;

    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        Health health = collider.gameObject.GetComponent<Health>();
        if (health && attacker)
        {
            health.DealDamage(Damage);
            Destroy(gameObject);
        }
    }
}
