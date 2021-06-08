using UnityEngine;
using UnityEngine.EventSystems;

public class RestartButton : ParentButton
{
    public GameObject menu;

    public override void OnPointerDown(PointerEventData eventData)
    {
        menu.SetActive(false);
        GameController.ReLoadCurrentLevel();
        base.OnPointerDown(eventData);
    }
}