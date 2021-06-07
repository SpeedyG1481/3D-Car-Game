using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LeftAndRightButton : MonoBehaviour
{
    private Button _button;

    public bool left = false;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        if (left)
        {
            GarageController.TargetIndex--;
        }
        else
        {
            GarageController.TargetIndex++;
        }
    }
}