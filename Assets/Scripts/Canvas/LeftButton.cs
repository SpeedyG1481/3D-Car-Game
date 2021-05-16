using UnityEngine.EventSystems;

public class LeftButton : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Vehicle.HorizontalInput = -1.0F;
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vehicle.HorizontalInput = 0;
        Up();
    }
}