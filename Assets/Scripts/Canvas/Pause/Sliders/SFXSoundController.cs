using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSoundController : MonoBehaviour
{
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(UpdateValue);
        _slider.value = PlayerPrefs.GetFloat("SFXSound");
    }

    private void UpdateValue(float value)
    {
        PlayerPrefs.SetFloat("SFXSound", value);
        _slider.value = value;
    }
}
