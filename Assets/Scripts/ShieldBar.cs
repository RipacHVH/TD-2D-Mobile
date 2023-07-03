using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    Color ShieldColor;

    public void SetShield(float ShieldAmount, float ShieldMax)
    {
        Slider.gameObject.SetActive(ShieldAmount < ShieldMax && ShieldAmount > 0);
        Slider.value = ShieldAmount;
        Slider.maxValue = ShieldMax;
        ShieldColor = Color.Lerp(Low, High, Slider.normalizedValue);
        Slider.fillRect.GetComponentInChildren<Image>().color = ShieldColor;
    }
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
