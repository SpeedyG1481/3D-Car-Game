using UnityEngine;

public static class GameController
{
    public static bool DebugMode = true;

    public static float GetMusicVolume => PlayerPrefs.GetFloat("MusicSound");
    public static float GetSfxVolume => PlayerPrefs.GetFloat("SFXSound");

    public static void GetDebugInputs()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        Vehicle.Gas = vertical > 0;
        Vehicle.Brake = vertical < 0;
        Vehicle.HorizontalInput = horizontal;
        Vehicle.BoostParam = Input.GetKey(KeyCode.Space);
    }

    public static int BrakeCount => PlayerPrefs.GetInt(ComponentType.Brake.ToString());
    public static int MotorCount => PlayerPrefs.GetInt(ComponentType.Motor.ToString());
    public static int TurboCount => PlayerPrefs.GetInt(ComponentType.Turbo.ToString());
    public static int AmmoCount => PlayerPrefs.GetInt(ComponentType.Ammo.ToString());
    public static int SuspensionCount => PlayerPrefs.GetInt(ComponentType.Suspension.ToString());
    public static int SteelCount => PlayerPrefs.GetInt(ComponentType.Steel.ToString());
    public static int CapsuleCount => PlayerPrefs.GetInt(ComponentType.Capsule.ToString());
    public static int GasolineCount => PlayerPrefs.GetInt(ComponentType.Gasoline.ToString());


    public static void Add(ComponentType type, int? count)
    {
        int realCount;
        switch (type)
        {
            case ComponentType.Brake:
                realCount = BrakeCount;
                break;
            case ComponentType.Motor:
                realCount = MotorCount;
                break;
            case ComponentType.Turbo:
                realCount = TurboCount;
                break;
            case ComponentType.Capsule:
                realCount = CapsuleCount;
                break;
            case ComponentType.Gasoline:
                realCount = GasolineCount;
                break;
            case ComponentType.Steel:
                realCount = SteelCount;
                break;
            case ComponentType.Suspension:
                realCount = SuspensionCount;
                break;
            case ComponentType.Ammo:
                realCount = AmmoCount;
                break;
            default:
                return;
        }

        if (!count.HasValue || count == 0)
            return;


        realCount += count.Value;
        PlayerPrefs.SetInt(type.ToString(), realCount);
    }
}