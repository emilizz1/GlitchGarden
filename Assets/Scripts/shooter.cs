using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start(){
		animator = GameObject.FindObjectOfType<Animator> ();

		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner ();
	}
	void Update(){
		if (IsAttackerAheadInLane()){
			animator.SetBool ("isAttacking" , true);
		} else {
			animator.SetBool ("isAttacking" , false);
		}
	}

	void SetMyLaneSpawner (){
		Spawner[] Spawners = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawn in Spawners) {
			if (spawn.transform.position.y == transform.position.y){
				myLaneSpawner = spawn;
			}
		}
	}

	bool IsAttackerAheadInLane (){
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		foreach (Transform child in myLaneSpawner.transform) {
			if (child.transform.position.x > transform.position.x){
				return true;
			}
		}
		return false;
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile)as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
