using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public void GiveCurrentHealth( float currentHealth)
    {
        GetComponent<Image>().fillAmount = currentHealth;
    }
}
