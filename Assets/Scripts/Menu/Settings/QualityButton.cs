using System;
using UnityEngine;
using UnityEngine.UI;

public class QualityButton : MonoBehaviour
{
    [SerializeField] private QualityTypes qualityTypes;
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

        foreach (var qualityType in (QualityTypes[]) Enum.GetValues(typeof(QualityTypes)))
        {
            if (qualityType == qualityTypes)
            {
                break;
            }

            i++;
        }

        GameController.SetQualityLevel(qualityTypes);
    }

    private void Update()
    {
        if (GameController.GetCurrentQuality() == qualityTypes)
        {
            _image.color = Color.green;
        }
        else
        {
            _image.color = Color.white;
        }
    }
}