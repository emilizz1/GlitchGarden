using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime;

    private Image fadePanel;
    private Color currentCollor = Color.black;
    
    void Start()
    {
        fadePanel = GetComponent<Image>();
    }
    
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentCollor.a -= alphaChange;
            fadePanel.color = currentCollor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
