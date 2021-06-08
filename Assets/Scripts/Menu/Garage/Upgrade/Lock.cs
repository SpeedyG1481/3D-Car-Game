using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private GameObject[] activate;
    [SerializeField] private GameObject[] disable;


    void Update()
    {
        foreach (var a in activate)
        {
            a.SetActive(GameController.GetCurrentCar == Vehicles.KnightRider ||
                        GameController.GetCurrentCar == Vehicles.Fustang);
        }

        foreach (var a in disable)
        {
            a.SetActive(!(GameController.GetCurrentCar == Vehicles.KnightRider ||
                          GameController.GetCurrentCar == Vehicles.Fustang));
        }
    }
}