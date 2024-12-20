using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setBarColor(Color color){
        slider.gameObject.transform.Find("Fill_P").GetComponent<Image>().color = color;
    }

    public void SetMaxHealth(int maxHealth){
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int Health){
        slider.value = Health;
    }
}
