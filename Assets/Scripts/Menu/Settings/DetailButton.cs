using System;
using UnityEngine;
using UnityEngine.UI;

public class DetailButton : MonoBehaviour
{
    [SerializeField] private DetailType detailType;
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

        foreach (var qualityType in (DetailType[]) Enum.GetValues(typeof(DetailType)))
        {
            if (qualityType == detailType)
            {
                break;
            }

            i++;
        }

        GameController.SetDetailLevel(detailType);
    }

    private void Update()
    {
        if (GameController.GetCurrentDetailLevel() == detailType)
        {
            _image.color = Color.green;
        }
        else
        {
            _image.color = Color.white;
        }
    }
}