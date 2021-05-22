using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class MenuButton : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{

    public GameObject menu;

    public override void Start()
    {
        base.Start();
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Up();
    }
}