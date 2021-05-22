using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeButton : ParentButton
{
    public GameObject menu;
    
    public override void OnPointerDown(PointerEventData eventData)
    {
        menu.SetActive(false);
        base.OnPointerDown(eventData);
    }
}
