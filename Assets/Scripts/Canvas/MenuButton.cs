using UnityEngine.EventSystems;

public class MenuButton : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{

    public override void Start()
    {
        base.Start();
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Up();
    }
}