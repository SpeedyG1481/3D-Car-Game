﻿using System;
using UnityEngine;

public static class GameController
{
    public static readonly int TargetFPS = 300;

    public static readonly string RewardedTestId = "ca-app-pub-3940256099942544/5224354917";
    public static readonly string InterstitialTestId = "ca-app-pub-3940256099942544/1033173712";

    public static readonly int TotalUpgrade = 7;
    public static readonly bool DebugMode = false;

    public static int CurrentPlayingLevel = 1;
    public static int CurrentPlayingCar = 1;

    public static float GetMusicVolume
    {
        get
        {
            if (PlayerPrefs.HasKey("MusicSound"))
                return PlayerPrefs.GetFloat("MusicSound");
            else
                return 0.25F;
        }
    }

    public static float GetSfxVolume
    {
        get
        {
            if (PlayerPrefs.HasKey("SFXSound"))
                return PlayerPrefs.GetFloat("SFXSound");
            else
                return 0.25F;
        }
    }

    public static int GetCurrentLevel => PlayerPrefs.GetInt("LevelValue") == 0 ? 1 : PlayerPrefs.GetInt("LevelValue");

    public static bool CanPlay(int level)
    {
        return GetCurrentLevel > level - 1;
    }

    public static void GoNextLevel()
    {
        if (CurrentPlayingLevel > GetCurrentLevel)
            return;

        switch (CurrentPlayingLevel)
        {
            case 1:
                OpenCar(Vehicles.Sedan);
                break;
            case 2:
                OpenCar(Vehicles.Pickup);
                break;
            case 3:
                OpenCar(Vehicles.Bugee);
                OpenCar(Vehicles.Military6X6);
                break;
            // case 4:
            //     OpenCar(Vehicles.Fustang);
            //     break;
        }

        PlayerPrefs.SetInt("LevelValue", CurrentPlayingLevel + 1);
    }

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

    public static void OpenCar(Vehicles vehicle)
    {
        PlayerPrefs.SetInt(vehicle.ToString(), 1);
    }

    public static CameraTypes GetCurrentCamera()
    {
        var cameraTypes = CameraTypes.Tps;
        var cameraType = PlayerPrefs.GetString("CameraType");

        foreach (var camera in (CameraTypes[]) Enum.GetValues(typeof(CameraTypes)))
        {
            if (camera.ToString() == cameraType)
            {
                cameraTypes = camera;
                break;
            }
        }

        return cameraTypes;
    }

    public static void ChangeCameraPosition()
    {
        switch (GetCurrentCamera())
        {
            case CameraTypes.Left:
                PlayerPrefs.SetString("CameraType", CameraTypes.Tps.ToString());
                break;
            case CameraTypes.Right:
                PlayerPrefs.SetString("CameraType", CameraTypes.Left.ToString());
                break;
            case CameraTypes.Tps:
                PlayerPrefs.SetString("CameraType", CameraTypes.Right.ToString());
                break;
        }
    }

    public static void ReLoadCurrentLevel()
    {
        switch (CurrentPlayingLevel)
        {
            case 1:
                SceneLoader.Load(Scenes.Level1);
                break;
            case 2:
                SceneLoader.Load(Scenes.Level2);
                break;
            case 3:
                SceneLoader.Load(Scenes.Level3);
                break;
            case 4:
                SceneLoader.Load(Scenes.Level4);
                break;
        }
    }

    public static QualityTypes GetCurrentQuality()
    {
        switch (PlayerPrefs.GetInt("QualitySettings"))
        {
            case 0:
                return QualityTypes.VeryLow;
            case 1:
                return QualityTypes.Low;
            case 2:
                return QualityTypes.Medium;
            case 3:
                return QualityTypes.High;
            case 4:
                return QualityTypes.UltraHd;
        }

        return QualityTypes.VeryLow;
    }

    public static SteeringTypes GetCurrentSteeringType()
    {
        var steering = SteeringTypes.Wheel;
        var steeringStoreValue = PlayerPrefs.GetString("SteeringType");

        foreach (var steeringType in (SteeringTypes[]) Enum.GetValues(typeof(SteeringTypes)))
        {
            if (steeringType.ToString() == steeringStoreValue)
            {
                steering = steeringType;
                break;
            }
        }

        return steering;
    }

    public static void SetSteeringType(SteeringTypes steeringType)
    {
        PlayerPrefs.SetString("SteeringType", steeringType.ToString());
    }


    public static void SetQualityLevel(QualityTypes qualityTypes)
    {
        var index = 0;
        switch (qualityTypes)
        {
            case QualityTypes.Low:
                index = 1;
                break;
            case QualityTypes.Medium:
                index = 2;
                break;
            case QualityTypes.High:
                index = 3;
                break;
            case QualityTypes.UltraHd:
                index = 4;
                break;
        }

        PlayerPrefs.SetInt("QualitySettings", index);
        QualitySettings.SetQualityLevel(index, true);
    }

    public static void SetDetailLevel(DetailType detailType)
    {
        PlayerPrefs.SetString("DetailSettings", detailType.ToString());
    }

    public static DetailType GetCurrentDetailLevel()
    {
        var detail = DetailType.Low;
        var detailStoreValue = PlayerPrefs.GetString("DetailSettings");

        foreach (var detailType in (DetailType[]) Enum.GetValues(typeof(DetailType)))
        {
            if (detailType.ToString() == detailStoreValue)
            {
                detail = detailType;
                break;
            }
        }

        return detail;
    }
}