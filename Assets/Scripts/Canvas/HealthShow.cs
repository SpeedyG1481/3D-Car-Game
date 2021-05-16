using UnityEngine;
using UnityEngine.UI;

public class HealthShow : MonoBehaviour
{
    private Vehicle _vehicle;
    private Slider _slider;

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

        _slider = GetComponent<Slider>();
        _canShow = _slider != null && _vehicle != null;
    }

    void Update()
    {
        if (_canShow)
        {
            _slider.value = _vehicle.HealthPercentage;
        }
    }
}