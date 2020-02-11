using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void SetHealth(float x)
    {
        slider.value = x;
    }

    public void SetMaxHealth(float x)
    {
        slider.maxValue = x;
    }
}
