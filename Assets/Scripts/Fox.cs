using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private Animator animator;
    private Attacker attacker;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        if (obj.GetComponent<Stone>())
        {
            animator.SetTrigger("jump trigger");
        }
        else
        {
            animator.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }
    }
}
