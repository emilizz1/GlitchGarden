using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	public float Speed;
	public float Damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Speed * Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D collider){
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health health = collider.gameObject.GetComponent<Health> ();
		if(health && attacker){
			health.DealDamage(Damage);
			Destroy (gameObject);
			}
			}
		}
