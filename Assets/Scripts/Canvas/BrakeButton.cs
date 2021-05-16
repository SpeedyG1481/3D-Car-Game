using UnityEngine.EventSystems;

public class BrakeButton : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Vehicle.Brake = true;
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vehicle.Brake = false;
        Up();
    }
}