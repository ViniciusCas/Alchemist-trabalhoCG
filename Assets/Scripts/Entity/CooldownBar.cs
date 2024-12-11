using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{

    public Slider cooldownSlider;

    public void SetCooldown(float cd)
    {
        cooldownSlider.value = cd;
    }

    public void SetMaxCooldown(float max)
    {
        cooldownSlider.maxValue = max;
        cooldownSlider.value = max;
    }
}
