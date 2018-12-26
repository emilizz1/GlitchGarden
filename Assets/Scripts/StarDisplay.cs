using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour
{
	[SerializeField] int startingAmout = 100;

    int amount;
	private Text text;
	public enum Status {SUCCESS, FAILURE};
    
	void Start ()
    {
		text = GetComponent<Text> ();
        amount = startingAmout;
		UpdateDisplay ();
	}

	public void AddStars(int amount)
    {
        amount += amount;
		UpdateDisplay();
	}

	public Status UseStars (int amount)
    {
		if (this.amount <= amount)
        {
            amount -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		} 
		return Status.FAILURE;
	}
	private void UpdateDisplay()
    {
		text.text = amount.ToString ();
	}
}
