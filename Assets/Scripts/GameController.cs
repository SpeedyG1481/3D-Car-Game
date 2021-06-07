using UnityEngine;

public static class GameController
{
    public static readonly int TotalUpgrade = 7;
    public static readonly bool DebugMode = true;


    public static int CurrentPlayingLevel = 1;
    public static int CurrentPlayingCar = 1;

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

    public static int BrakeCount
    {
        get => PlayerPrefs.GetInt(ComponentType.Brake.ToString());
        set => PlayerPrefs.SetInt(ComponentType.Brake.ToString(), value);
    }

    public static int MotorCount
    {
        get => PlayerPrefs.GetInt(ComponentType.Motor.ToString());
        set => PlayerPrefs.SetInt(ComponentType.Motor.ToString(), value);
    }

    public static int TurboCount
    {
        get => PlayerPrefs.GetInt(ComponentType.Turbo.ToString());
        set => PlayerPrefs.SetInt(ComponentType.Turbo.ToString(), value);
    }

    public static int AmmoCount
    {
        get => PlayerPrefs.GetInt(ComponentType.Ammo.ToString());
        set => PlayerPrefs.SetInt(ComponentType.Ammo.ToString(), value);
    }

    public static int SuspensionCount
    {
        get => PlayerPrefs.GetInt(ComponentType.Suspension.ToString());
        set => PlayerPrefs.SetInt(ComponentType.Suspension.ToString(), value);
    }

    public static int SteelCount
    {
        get => PlayerPrefs.GetInt(ComponentType.Steel.ToString());
        set => PlayerPrefs.SetInt(ComponentType.Steel.ToString(), value);
    }

    public static int CapsuleCount
    {
        get => PlayerPrefs.GetInt(ComponentType.Capsule.ToString());
        set => PlayerPrefs.SetInt(ComponentType.Capsule.ToString(), value);
    }

    public static int GasolineCount
    {
        get => PlayerPrefs.GetInt(ComponentType.Gasoline.ToString());
        set => PlayerPrefs.SetInt(ComponentType.Gasoline.ToString(), value);
    }


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

    public static GroundData GroundStiffness(int layer)
    {
        var groundType = GroundType.Asphalt;
        switch (CurrentPlayingLevel)
        {
            case 1:
                switch (layer)
                {
                    case 1:
                        groundType = GroundType.OldAsphalt;
                        break;
                }

                break;
            case 2:
                switch (layer)
                {
                    case 0:
                        groundType = GroundType.Sand;
                        break;
                }

                break;
            case 3:
                switch (layer)
                {
                    case 0:
                        groundType = GroundType.Snow;
                        break;
                    case 1:
                        groundType = GroundType.Ice;
                        break;
                }

                break;
            case 4:
                switch (layer)
                {
                    case 0:
                        groundType = GroundType.Dirt;
                        break;
                }

                break;
        }

        return new GroundData(groundType);
    }

    public static Vehicles GetCurrentCar
    {
        get
        {
            switch (CurrentPlayingCar)
            {
                case 2:
                    return Vehicles.Sedan;
                case 3:
                    return Vehicles.Pickup;
                case 4:
                    return Vehicles.Bugee;
                case 5:
                    return Vehicles.Military6X6;
                case 6:
                    return Vehicles.Fustang;
                case 7:
                    return Vehicles.KnightRider;
                default:
                    return Vehicles.Hatchback;
            }
        }
    }

    public static bool CanUseCar()
    {
        return GetCurrentCar == Vehicles.Hatchback || PlayerPrefs.GetInt(GetCurrentCar.ToString()) > 0;
    }

    public static bool CanUpgradeCarLevel(UpgradeType upgradeType)
    {
        var upgrade = Upgrade.GetUpgradeData(upgradeType);
        var canUpgradeThisCar = AmmoCount >= upgrade.AmmoNeed && BrakeCount >= upgrade.BrakeNeed &&
                                CapsuleCount >= upgrade.CapsuleNeed && SuspensionCount >= upgrade.SuspensionNeed &&
                                MotorCount >= upgrade.MotorNeed && TurboCount >= upgrade.TurboNeed &&
                                SteelCount >= upgrade.SteelNeed && GasolineCount >= upgrade.GasolineNeed;
        var isMaxUpgrade = GetCurrentUpgradeLevel(upgradeType) < TotalUpgrade;

        return CanUseCar() && canUpgradeThisCar && isMaxUpgrade;
    }

    public static int GetCurrentUpgradeLevel(UpgradeType upgradeType)
    {
        return PlayerPrefs.GetInt(GetCurrentCar.ToString() + "_" + upgradeType.ToString());
    }

    public static void UpgradePartLevel(UpgradeType upgradeType)
    {
        var upgrade = Upgrade.GetUpgradeData(upgradeType);
        AmmoCount -= upgrade.AmmoNeed;
        BrakeCount -= upgrade.BrakeNeed;
        CapsuleCount -= upgrade.CapsuleNeed;
        GasolineCount -= upgrade.GasolineNeed;
        MotorCount -= upgrade.MotorNeed;
        SteelCount -= upgrade.SteelNeed;
        SuspensionCount -= upgrade.SuspensionNeed;
        TurboCount -= upgrade.TurboNeed;

        var current = PlayerPrefs.GetInt(GetCurrentCar.ToString() + "_" + upgradeType.ToString());
        current++;
        PlayerPrefs.SetInt(GetCurrentCar.ToString() + "_" + upgradeType.ToString(), current);
    }
}