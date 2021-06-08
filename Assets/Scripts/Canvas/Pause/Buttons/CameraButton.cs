using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraButton : ParentButton
{
    public GameObject menu;
    
    public override void OnPointerDown(PointerEventData eventData)
    {
    
        menu.SetActive(false);
        GameController.ChangeCameraPosition();
        base.OnPointerDown(eventData);
    }
}
