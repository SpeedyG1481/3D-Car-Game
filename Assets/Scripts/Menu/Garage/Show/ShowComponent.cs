using TMPro;
using UnityEngine;

public class ShowComponent : MonoBehaviour
{
    [SerializeField] private ComponentType componentType;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        switch (componentType)
        {
            case ComponentType.Brake:
                _text.text = GameController.BrakeCount.ToString();
                break;
            case ComponentType.Motor:
                _text.text = GameController.MotorCount.ToString();
                break;
            case ComponentType.Turbo:
                _text.text = GameController.TurboCount.ToString();
                break;
            case ComponentType.Capsule:
                _text.text = GameController.CapsuleCount.ToString();
                break;
            case ComponentType.Gasoline:
                _text.text = GameController.GasolineCount.ToString();
                break;
            case ComponentType.Steel:
                _text.text = GameController.SteelCount.ToString();
                break;
            case ComponentType.Suspension:
                _text.text = GameController.SuspensionCount.ToString();
                break;
            case ComponentType.Ammo:
                _text.text = GameController.AmmoCount.ToString();
                break;
            default:
                break;
        }
    }
}