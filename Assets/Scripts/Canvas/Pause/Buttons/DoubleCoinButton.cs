using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoubleCoinButton : ParentButton
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
            _vehicle.DoubleComponent();
            SceneLoader.Load(Scenes.Garage);
            _vehicle.CanUseDoubleComponent = false;
            
        }
    }
}