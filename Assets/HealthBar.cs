using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Vector2 posOffset;
    [SerializeField] Vector2 size = new Vector2(60, 20);
    [SerializeField] Texture2D emptyTex;
    [SerializeField] Texture2D fullTex;
    
    float currentProgress;
    Vector2 pos;

    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * currentProgress, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    public void SetPosition(Vector2 newPos)
    {
        pos = newPos + posOffset;
    }

    public void GiveCurrentHealth( float currentHealth)
    {
        currentProgress = currentHealth;
    }
}
