using UnityEngine.EventSystems;

public class RightRotate : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Vehicle.RotationInput = 1.0F;
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vehicle.RotationInput = 0;
        Up();
    }
}