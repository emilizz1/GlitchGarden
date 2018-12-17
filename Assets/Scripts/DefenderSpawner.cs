using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;
	private StarDisplay starDisplay;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		parent = GameObject.Find ("Defenders");
		
		if (!parent) {
			parent = new GameObject("Defenders");
		}
		
	}

	void OnMouseDown (){
		int defenderCost = Button.selectedDefender.GetComponent<Defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
		GameObject newDefender = Instantiate (Button.selectedDefender, SnapToGrid(CalculateWorldPointOfMouseClick()), Quaternion.identity) as GameObject;
			newDefender.transform.parent = parent.transform;
		}
	}

	Vector2 SnapToGrid (Vector2 rawPos){
		float newX = Mathf.RoundToInt (rawPos.x);
		float newY = Mathf.RoundToInt (rawPos.y);
		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick (){
		float mouseX = Input.mousePosition.x;
		float moussY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, moussY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}
}
