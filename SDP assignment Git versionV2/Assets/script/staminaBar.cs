using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setStamina(float stamina)
    {
        slider.value = stamina;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = 0;

        fill.color = gradient.Evaluate(1f);
    }
}
