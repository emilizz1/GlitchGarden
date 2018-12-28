using UnityEngine;

public class shredder : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D collider)
    {
        FindObjectOfType<LevelLives>().RemoveLife();
		Destroy (collider.gameObject);
	}
}
