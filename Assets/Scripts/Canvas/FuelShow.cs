using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelShow : MonoBehaviour
{
    private Vehicle _vehicle;
    private Image _image;

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

        _image = GetComponent<Image>();
        _canShow = _image != null && _vehicle != null;
    }

    void Update()
    {
        if (_canShow)
        {
            _image.fillAmount = _vehicle.FuelPercentage;
        }
    }
}
