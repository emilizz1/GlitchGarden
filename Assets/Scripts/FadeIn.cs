using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;

	private Image fadePanel;
	private Color currentCollor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alphaChange = Time.deltaTime / fadeInTime;
			currentCollor.a -= alphaChange;
			fadePanel.color = currentCollor;
		} else {
			gameObject.SetActive (false);
		}
	}
}
