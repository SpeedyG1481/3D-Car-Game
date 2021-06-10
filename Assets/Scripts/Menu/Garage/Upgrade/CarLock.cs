using UnityEngine;

public class CarLock : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject knightRider;
    [SerializeField] private GameObject fustang;


    private void Update()
    {
        ui.SetActive(!GameController.CanUseCar());
        knightRider.SetActive(!GameController.CanUseCar() && GameController.GetCurrentCar == Vehicles.KnightRider);
        fustang.SetActive(!GameController.CanUseCar() && GameController.GetCurrentCar == Vehicles.Fustang);
    }
}