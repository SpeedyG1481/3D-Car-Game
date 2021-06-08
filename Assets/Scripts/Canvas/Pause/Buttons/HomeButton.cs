using UnityEngine;
using UnityEngine.EventSystems;

public class HomeButton : ParentButton
{
    public GameObject menu;

    public override void OnPointerDown(PointerEventData eventData)
    {
        menu.SetActive(false);
        SceneLoader.Load(Scenes.Garage);
        base.OnPointerDown(eventData);
    }
}