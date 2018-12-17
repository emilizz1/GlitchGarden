using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	public float seenEverySeconds;

	private float walkSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("IsAttacking", false);
		}
	}

	void OnTriggerEnter2D (){

	}
	public void ChangeSpeed(float speed){
		walkSpeed = speed;
	}
	public void StrikeCurrentTarget (float damage){
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if(health){
				health.DealDamage(damage);
			}
		}
	}
	public void Attack (GameObject obj){
		currentTarget = obj;
	}
}
