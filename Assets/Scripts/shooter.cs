using UnityEngine;

public class shooter : MonoBehaviour
{
	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Transform myLane;

	void Start()
    {
		animator = FindObjectOfType<Animator> ();
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent)
        {
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner ();
	}

	void Update()
    {
		if (IsAttackerAheadInLane())
        {
			animator.SetBool ("isAttacking" , true);
		} else
        {
			animator.SetBool ("isAttacking" , false);
		}
	}

	void SetMyLaneSpawner ()
    {
        foreach(GameObject lane in FindObjectOfType<Spawner>().GetComponentsInChildren<GameObject>())
        {
            if(transform.position.y == lane.transform.position.y)
            {
                myLane = lane.transform;
            }
        }
	}

	bool IsAttackerAheadInLane ()
    {
        if (myLane.childCount <= 0) { return false; }
		foreach (Transform child in myLane)
        {
			if (child.transform.position.x > transform.position.x)
            {
				return true;
			}
		}
		return false;
	}

	private void Fire()
    {
		GameObject newProjectile = Instantiate (projectile)as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
