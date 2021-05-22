using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensivityController : MonoBehaviour
{
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(UpdateValue);
        _slider.value = PlayerPrefs.GetFloat("Sensivity");
    }

    private void UpdateValue(float value)
    {
        PlayerPrefs.SetFloat("Sensivity", value);
        _slider.value = value;
    }
}