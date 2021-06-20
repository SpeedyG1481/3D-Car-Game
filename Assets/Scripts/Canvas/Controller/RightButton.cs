using UnityEngine.EventSystems;

public class RightButton : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Vehicle.HorizontalInput = 1.0F;
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vehicle.HorizontalInput = 0;
        Up();
    }
}