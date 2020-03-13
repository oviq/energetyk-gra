using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// interfejs miedzy ui paska zdrowia a klasa unit
public class HealthBar : MonoBehaviour
{
    public void SetHealth(float x)
    {
        GetComponent<Slider>().value = x;
    }

    public void SetMaxHealth(float x)
    {
        GetComponent<Slider>().maxValue = x;
    }
}
