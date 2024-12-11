using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthSlider; 

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void SetMaxHealth(int max)
    {
        healthSlider.maxValue = max;
        healthSlider.value = max;
    }
}
