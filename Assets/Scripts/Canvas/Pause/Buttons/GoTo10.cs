using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoTo10 : ParentButton
{
    public GameObject menu;
    private Vehicle _vehicle;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        foreach (var vehicles in FindObjectsOfType<Vehicle>())
        {
            if (vehicles.gameObject.activeInHierarchy)
            {
                _vehicle = vehicles;
            }
        }
    }

    private void Update()
    {
        if (_vehicle != null)
            if (_vehicle.CanUseGoTo10)
            {
                _image.color = Color.grey;
            }
            else
            {
                _image.color = Color.white;
            }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        menu.SetActive(false);
        Reward();
        base.OnPointerDown(eventData);
    }

    public void Reward()
    {
        if (_vehicle != null)
        {
            _vehicle.AddFuel(_vehicle.MaxFuel / 9.5F);
            _vehicle.AddHeal(_vehicle.MaxHeal / 8.75F);
            _vehicle.Reset();
            _vehicle.CanUseGoTo10 = false;
        }
    }
}