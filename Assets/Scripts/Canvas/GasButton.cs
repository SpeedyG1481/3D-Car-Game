using UnityEngine;
using UnityEngine.EventSystems;

public class GasButton : ButtonEffect,IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Vehicle.Gas = true;
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vehicle.Gas = false;
        Up();
    }
}