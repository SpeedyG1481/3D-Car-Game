using UnityEngine;
using UnityEngine.EventSystems;

public class FPSButton : ParentButton
{
    public GameObject menu;

    public override void OnPointerDown(PointerEventData eventData)
    {
        menu.SetActive(false);
        var value = PlayerPrefs.GetInt("FpsCounter");
        if (value == 0)
        {
            value = int.MaxValue;
        }
        else
        {
            value = 0;
        }

        PlayerPrefs.SetInt("FpsCounter", value);
        base.OnPointerDown(eventData);
    }
}