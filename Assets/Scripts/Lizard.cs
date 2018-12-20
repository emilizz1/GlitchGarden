using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
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
        animator.SetBool("IsAttacking", true);
        attacker.Attack(obj);
    }
}