using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoostButton : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Vehicle.BoostParam = true;
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vehicle.BoostParam = false;
        Up();
    }
}
