using UnityEngine;

public class CarLock : MonoBehaviour
{
    [SerializeField] private GameObject ui;

    private void Update()
    {
        ui.SetActive(!GameController.CanUseCar());
    }
}