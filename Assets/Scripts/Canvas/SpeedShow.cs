using System;
using TMPro;
using UnityEngine;

public class SpeedShow : MonoBehaviour
{
    private Vehicle _vehicle;
    private TextMeshProUGUI _text;

    private bool _canShow;

    void Start()
    {
        var vehicles = FindObjectsOfType<Vehicle>();
        foreach (var v in vehicles)
        {
            if (v.isActiveAndEnabled)
            {
                _vehicle = v;
                break;
            }
        }

        _text = GetComponent<TextMeshProUGUI>();
        _canShow = _text != null && _vehicle != null;
    }

    void Update()
    {
        if (_canShow)
        {
            _text.text = ((int) Math.Round(Math.Abs(_vehicle.Speed))).ToString();
        }
    }
}