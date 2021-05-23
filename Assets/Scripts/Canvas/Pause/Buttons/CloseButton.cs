using UnityEngine;
using UnityEngine.EventSystems;

public class CloseButton : ParentButton
{
    public GameObject menu;

    public override void OnPointerDown(PointerEventData eventData)
    {
        
        menu.SetActive(false);
        base.OnPointerDown(eventData);
    }
}