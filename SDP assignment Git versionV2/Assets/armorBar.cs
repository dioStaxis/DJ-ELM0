using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armorBar : MonoBehaviour
{
    public Slider slider;

    public void setArmor(int armor)
    {
        slider.value = armor;
    }

}
