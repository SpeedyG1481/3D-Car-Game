using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSoundController : MonoBehaviour
{
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(UpdateValue);
        _slider.value = PlayerPrefs.GetFloat("MusicSound");
    }

    private void UpdateValue(float value)
    {
        PlayerPrefs.SetFloat("MusicSound", value);
        _slider.value = value;
    }
}