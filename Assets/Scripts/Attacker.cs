using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    private float walkSpeed;
    private GameObject currentTarget;
    private Animator animator;
    private HealthBar healthBar;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
    }
    
    void Update()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        healthBar.SetPosition(transform.position);
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void ChangeSpeed(float speed)
    {
        walkSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage) // called from animation
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
