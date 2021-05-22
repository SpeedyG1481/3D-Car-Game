using UnityEngine.EventSystems;

public class BoostButton : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Vehicle.Gas = true;
        Vehicle.BoostParam = true;
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vehicle.Gas = false;
        Vehicle.BoostParam = false;
        Up();
    }
}