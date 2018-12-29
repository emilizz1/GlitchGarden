using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    private float walkSpeed;
    private GameObject currentTarget;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
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
                float damageTakenBack = health.DealDamage(damage);
                if(damageTakenBack > 0)
                {
                    GetComponent<Health>().DealDamage(damageTakenBack);
                }
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
