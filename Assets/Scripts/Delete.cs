using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delete : MonoBehaviour
{
    public bool upgrade;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        if (upgrade)
        {
            GameController.AmmoCount += 1000;
            GameController.CapsuleCount += 1000;
            GameController.BrakeCount += 1000;
            GameController.GasolineCount += 1000;
            GameController.MotorCount += 1000;
            GameController.SteelCount += 1000;
            GameController.SuspensionCount += 1000;
            GameController.TurboCount += 1000;
            
            GameController.OpenCar(Vehicles.Sedan);
            GameController.OpenCar(Vehicles.Fustang);
            GameController.OpenCar(Vehicles.Bugee);
            GameController.OpenCar(Vehicles.KnightRider);
            GameController.OpenCar(Vehicles.Pickup);
            GameController.OpenCar(Vehicles.Military6X6);
            
    
        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
     
    }

  
}
