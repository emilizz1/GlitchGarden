using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text textCost;
    
    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        textCost = GetComponentInChildren<Text>();
        textCost.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
    }
    
    void Update()
    {

    }

    void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
