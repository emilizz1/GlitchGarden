using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private int Amout = 100;
	private Text text;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		UpdateDisplay ();
	}

	public void AddStars(int amount){
		Amout += amount;
		UpdateDisplay();
	}

	public Status UseStars (int amount){
		if (amount <= Amout) {
			Amout -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		} 
		return Status.FAILURE;
	}
	private void UpdateDisplay(){
		text.text = Amout.ToString ();
	}
}
