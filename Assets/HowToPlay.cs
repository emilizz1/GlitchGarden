using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] GameObject howToPlayText;
    
    void Start()
    {
        howToPlayText.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        howToPlayText.SetActive(true);
    }
}