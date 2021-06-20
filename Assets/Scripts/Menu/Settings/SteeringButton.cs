using System;
using UnityEngine;
using UnityEngine.UI;

public class SteeringButton : MonoBehaviour
{
    [SerializeField] private SteeringTypes steeringTypes;
    private Image _image;
    private Button _button;

    private void Start()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        var i = 0;

        foreach (var sValue in (SteeringTypes[]) Enum.GetValues(typeof(SteeringTypes)))
        {
            if (sValue == steeringTypes)
            {
                break;
            }

            i++;
        }

        GameController.SetSteeringType(steeringTypes);
    }

    private void Update()
    {
        if (GameController.GetCurrentSteeringType() == steeringTypes)
        {
            _image.color = Color.green;
        }
        else
        {
            _image.color = Color.white;
        }
    }
}