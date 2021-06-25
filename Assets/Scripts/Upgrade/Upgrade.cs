using UnityEngine;

public class Upgrade
{
    /*
     *
     * This values maximum upgrade needs for cars. If you want to x level need
     * you will use x(Current Upgrade Level) * Need / TotalUpgrade
     * 
     */

    //--------------------------------------------------------------
    //Hatchback
    //Engine
    private static readonly int HatchbackEngineMotor = 70;
    private static readonly int HatchbackEngineTurbo = 35;
    private static readonly int HatchbackEngineSteel = 42;

    //Brake
    private static readonly int HatchbackBrakeBrake = 56;
    private static readonly int HatchbackBrakeSuspension = 28;
    private static readonly int HatchbackBrakeSteel = 42;

    //Durability
    private static readonly int HatchbackDurabilitySteel = 84;
    private static readonly int HatchbackDurabilityCapsule = 63;

    //Boost
    private static readonly int HatchbackBoostTurbo = 63;
    private static readonly int HatchbackBoostMotor = 56;
    private static readonly int HatchbackBoostGasoline = 42;

    //Fuel
    private static readonly int HatchbackFuelGasoline = 77;
    private static readonly int HatchbackFuelMotor = 56;

    //Gun
    private static readonly int HatchbackGunAmmo = 84;
    private static readonly int HatchbackGunSteel = 63;

    //Sedan
    //Engine
    private static readonly int SedanEngineMotor = 84;
    private static readonly int SedanEngineTurbo = 56;
    private static readonly int SedanEngineSteel = 49;

    //Brake
    private static readonly int SedanBrakeBrake = 70;
    private static readonly int SedanBrakeSuspension = 35;
    private static readonly int SedanBrakeSteel = 56;

    //Durability
    private static readonly int SedanDurabilitySteel = 98;
    private static readonly int SedanDurabilityCapsule = 77;

    //Boost
    private static readonly int SedanBoostTurbo = 77;
    private static readonly int SedanBoostMotor = 63;
    private static readonly int SedanBoostGasoline = 49;

    //Fuel
    private static readonly int SedanFuelGasoline = 84;
    private static readonly int SedanFuelMotor = 63;

    //Gun
    private static readonly int SedanGunAmmo = 98;
    private static readonly int SedanGunSteel = 70;

    //Pickup
    //Engine
    private static readonly int PickupEngineMotor = 98;
    private static readonly int PickupEngineTurbo = 63;
    private static readonly int PickupEngineSteel = 56;

    //Brake
    private static readonly int PickupBrakeBrake = 84;
    private static readonly int PickupBrakeSuspension = 42;
    private static readonly int PickupBrakeSteel = 63;

    //Durability
    private static readonly int PickupDurabilitySteel = 112;
    private static readonly int PickupDurabilityCapsule = 84;

    //Boost
    private static readonly int PickupBoostTurbo = 91;
    private static readonly int PickupBoostMotor = 77;
    private static readonly int PickupBoostGasoline = 56;

    //Fuel
    private static readonly int PickupFuelGasoline = 98;
    private static readonly int PickupFuelMotor = 70;

    //Gun
    private static readonly int PickupGunAmmo = 112;
    private static readonly int PickupGunSteel = 77;

    //Bugee
    //Engine
    private static readonly int BugeeEngineMotor = 112;
    private static readonly int BugeeEngineTurbo = 70;
    private static readonly int BugeeEngineSteel = 63;

    //Brake
    private static readonly int BugeeBrakeBrake = 98;
    private static readonly int BugeeBrakeSuspension = 56;
    private static readonly int BugeeBrakeSteel = 70;

    //Durability
    private static readonly int BugeeDurabilitySteel = 126;
    private static readonly int BugeeDurabilityCapsule = 91;

    //Boost
    private static readonly int BugeeBoostTurbo = 105;
    private static readonly int BugeeBoostMotor = 84;
    private static readonly int BugeeBoostGasoline = 70;

    //Fuel
    private static readonly int BugeeFuelGasoline = 105;
    private static readonly int BugeeFuelMotor = 77;

    //Gun
    private static readonly int BugeeGunAmmo = 126;
    private static readonly int BugeeGunSteel = 84;

    //6x6 Military
    //Engine
    private static readonly int MilitaryEngineMotor = 119;
    private static readonly int MilitaryEngineTurbo = 77;
    private static readonly int MilitaryEngineSteel = 70;

    //Brake
    private static readonly int MilitaryBrakeBrake = 112;
    private static readonly int MilitaryBrakeSuspension = 63;
    private static readonly int MilitaryBrakeSteel = 77;

    //Durability
    private static readonly int MilitaryDurabilitySteel = 133;
    private static readonly int MilitaryDurabilityCapsule = 98;

    //Boost
    private static readonly int MilitaryBoostTurbo = 119;
    private static readonly int MilitaryBoostMotor = 91;
    private static readonly int MilitaryBoostGasoline = 77;

    //Fuel
    private static readonly int MilitaryFuelGasoline = 119;
    private static readonly int MilitaryFuelMotor = 91;

    //Gun
    private static readonly int MilitaryGunAmmo = 133;
    private static readonly int MilitaryGunSteel = 91;


    //Fustang
    //Engine
    private static readonly int FustangEngineMotor = 98;
    private static readonly int FustangEngineTurbo = 63;
    private static readonly int FustangEngineSteel = 56;

    //Brake
    private static readonly int FustangBrakeBrake = 84;
    private static readonly int FustangBrakeSuspension = 42;
    private static readonly int FustangBrakeSteel = 63;

    //Durability
    private static readonly int FustangDurabilitySteel = 112;
    private static readonly int FustangDurabilityCapsule = 84;

    //Boost
    private static readonly int FustangBoostTurbo = 91;
    private static readonly int FustangBoostMotor = 77;
    private static readonly int FustangBoostGasoline = 56;

    //Fuel
    private static readonly int FustangFuelGasoline = 98;
    private static readonly int FustangFuelMotor = 70;

    //Gun
    private static readonly int FustangGunAmmo = 112;
    private static readonly int FustangGunSteel = 77;

    //Ability
    private static readonly int FustangAbilitySteel = 56;
    private static readonly int FustangAbilityCapsule = 70;
    private static readonly int FustangAbilityGasoline = 91;

    //KnightRider
    //Engine
    private static readonly int KnightRiderEngineMotor = 112;
    private static readonly int KnightRiderEngineTurbo = 70;
    private static readonly int KnightRiderEngineSteel = 63;

    //Brake
    private static readonly int KnightRiderBrakeBrake = 98;
    private static readonly int KnightRiderBrakeSuspension = 56;
    private static readonly int KnightRiderBrakeSteel = 70;

    //Durability
    private static readonly int KnightRiderDurabilitySteel = 126;
    private static readonly int KnightRiderDurabilityCapsule = 91;

    //Boost
    private static readonly int KnightRiderBoostTurbo = 105;
    private static readonly int KnightRiderBoostMotor = 84;
    private static readonly int KnightRiderBoostGasoline = 70;

    //Fuel
    private static readonly int KnightRiderFuelGasoline = 105;
    private static readonly int KnightRiderFuelMotor = 77;

    //Gun
    private static readonly int KnightRiderGunAmmo = 126;
    private static readonly int KnightRiderGunSteel = 84;

    //Ability
    private static readonly int KnightRiderAbilitySuspension = 91;
    private static readonly int KnightRiderAbilitySteel = 84;

    private static readonly int KnightRiderAbilityTurbo = 56;
    //--------------------------------------------------------------

    private int _brakeNeed;
    private int _motorNeed;
    private int _turboNeed;
    private int _gasolineNeed;
    private int _steelNeed;
    private int _suspensionNeed;
    private int _ammoNeed;
    private int _capsuleNeed;

    public int BrakeNeed => _brakeNeed;
    public int MotorNeed => _motorNeed;
    public int TurboNeed => _turboNeed;
    public int GasolineNeed => _gasolineNeed;
    public int SteelNeed => _steelNeed;
    public int SuspensionNeed => _suspensionNeed;
    public int AmmoNeed => _ammoNeed;
    public int CapsuleNeed => _capsuleNeed;


    public static Upgrade GetUpgradeData(UpgradeType upgradeType)
    {
        var brakeNeed = 0;
        var motorNeed = 0;
        var turboNeed = 0;
        var gasolineNeed = 0;
        var steelNeed = 0;
        var suspensionNeed = 0;
        var ammoNeed = 0;
        var capsuleNeed = 0;

        var currentUpgradeLevel = GameController.GetCurrentUpgradeLevel(upgradeType) + 1;

        switch (GameController.GetCurrentCar)
        {
            case Vehicles.Hatchback:
                switch (upgradeType)
                {
                    case UpgradeType.Engine:
                        motorNeed = HatchbackEngineMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        turboNeed = HatchbackEngineTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = HatchbackEngineSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Boost:
                        turboNeed = HatchbackBoostTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = HatchbackBoostMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        gasolineNeed = HatchbackBoostGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Brake:
                        brakeNeed = HatchbackBrakeBrake * currentUpgradeLevel / GameController.TotalUpgrade;
                        suspensionNeed = HatchbackBrakeSuspension * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = HatchbackBrakeSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Durability:
                        steelNeed = HatchbackDurabilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        capsuleNeed = HatchbackDurabilityCapsule * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Fuel:
                        gasolineNeed = HatchbackFuelGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = HatchbackFuelMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Gun:
                        ammoNeed = HatchbackGunAmmo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = HatchbackGunSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                }

                break;
            case Vehicles.Sedan:
                switch (upgradeType)
                {
                    case UpgradeType.Engine:
                        motorNeed = SedanEngineMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        turboNeed = SedanEngineTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = SedanEngineSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Boost:
                        turboNeed = SedanBoostTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = SedanBoostMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        gasolineNeed = SedanBoostGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Brake:
                        brakeNeed = SedanBrakeBrake * currentUpgradeLevel / GameController.TotalUpgrade;
                        suspensionNeed = SedanBrakeSuspension * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = SedanBrakeSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Durability:
                        steelNeed = SedanDurabilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        capsuleNeed = SedanDurabilityCapsule * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Fuel:
                        gasolineNeed = SedanFuelGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = SedanFuelMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Gun:
                        ammoNeed = SedanGunAmmo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = SedanGunSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                }

                break;
            case Vehicles.Pickup:
                switch (upgradeType)
                {
                    case UpgradeType.Engine:
                        motorNeed = PickupEngineMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        turboNeed = PickupEngineTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = PickupEngineSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Boost:
                        turboNeed = PickupBoostTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = PickupBoostMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        gasolineNeed = PickupBoostGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Brake:
                        brakeNeed = PickupBrakeBrake * currentUpgradeLevel / GameController.TotalUpgrade;
                        suspensionNeed = PickupBrakeSuspension * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = PickupBrakeSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Durability:
                        steelNeed = PickupDurabilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        capsuleNeed = PickupDurabilityCapsule * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Fuel:
                        gasolineNeed = PickupFuelGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = PickupFuelMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Gun:
                        ammoNeed = PickupGunAmmo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = PickupGunSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                }

                break;
            case Vehicles.Bugee:
                switch (upgradeType)
                {
                    case UpgradeType.Engine:
                        motorNeed = BugeeEngineMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        turboNeed = BugeeEngineTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = BugeeEngineSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Boost:
                        turboNeed = BugeeBoostTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = BugeeBoostMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        gasolineNeed = BugeeBoostGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Brake:
                        brakeNeed = BugeeBrakeBrake * currentUpgradeLevel / GameController.TotalUpgrade;
                        suspensionNeed = BugeeBrakeSuspension * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = BugeeBrakeSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Durability:
                        steelNeed = BugeeDurabilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        capsuleNeed = BugeeDurabilityCapsule * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Fuel:
                        gasolineNeed = BugeeFuelGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = BugeeFuelMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Gun:
                        ammoNeed = BugeeGunAmmo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = BugeeGunSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                }

                break;
            case Vehicles.Military6X6:
                switch (upgradeType)
                {
                    case UpgradeType.Engine:
                        motorNeed = MilitaryEngineMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        turboNeed = MilitaryEngineTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = MilitaryEngineSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Boost:
                        turboNeed = MilitaryBoostTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = MilitaryBoostMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        gasolineNeed = MilitaryBoostGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Brake:
                        brakeNeed = MilitaryBrakeBrake * currentUpgradeLevel / GameController.TotalUpgrade;
                        suspensionNeed = MilitaryBrakeSuspension * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = MilitaryBrakeSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Durability:
                        steelNeed = MilitaryDurabilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        capsuleNeed = MilitaryDurabilityCapsule * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Fuel:
                        gasolineNeed = MilitaryFuelGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = MilitaryFuelMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Gun:
                        ammoNeed = MilitaryGunAmmo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = MilitaryGunSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                }

                break;
            case Vehicles.Fustang:
                switch (upgradeType)
                {
                    case UpgradeType.Engine:
                        motorNeed = FustangEngineMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        turboNeed = FustangEngineTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = FustangEngineSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Boost:
                        turboNeed = FustangBoostTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = FustangBoostMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        gasolineNeed = FustangBoostGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Brake:
                        brakeNeed = FustangBrakeBrake * currentUpgradeLevel / GameController.TotalUpgrade;
                        suspensionNeed = FustangBrakeSuspension * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = FustangBrakeSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Durability:
                        steelNeed = FustangDurabilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        capsuleNeed = FustangDurabilityCapsule * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Fuel:
                        gasolineNeed = FustangFuelGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = FustangFuelMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Gun:
                        ammoNeed = FustangGunAmmo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = FustangGunSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Ability:
                        steelNeed = FustangAbilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        capsuleNeed = FustangAbilityCapsule * currentUpgradeLevel / GameController.TotalUpgrade;
                        gasolineNeed = FustangAbilityGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                }

                break;
            case Vehicles.KnightRider:
                switch (upgradeType)
                {
                    case UpgradeType.Engine:
                        motorNeed = KnightRiderEngineMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        turboNeed = KnightRiderEngineTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = KnightRiderEngineSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Boost:
                        turboNeed = KnightRiderBoostTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = KnightRiderBoostMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        gasolineNeed = KnightRiderBoostGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Brake:
                        brakeNeed = KnightRiderBrakeBrake * currentUpgradeLevel / GameController.TotalUpgrade;
                        suspensionNeed = KnightRiderBrakeSuspension * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = KnightRiderBrakeSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Durability:
                        steelNeed = KnightRiderDurabilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        capsuleNeed = KnightRiderDurabilityCapsule * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Fuel:
                        gasolineNeed = KnightRiderFuelGasoline * currentUpgradeLevel / GameController.TotalUpgrade;
                        motorNeed = KnightRiderFuelMotor * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Gun:
                        ammoNeed = KnightRiderGunAmmo * currentUpgradeLevel / GameController.TotalUpgrade;
                        steelNeed = KnightRiderGunSteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                    case UpgradeType.Ability:
                        suspensionNeed = KnightRiderAbilitySuspension * currentUpgradeLevel /
                                         GameController.TotalUpgrade;
                        steelNeed = KnightRiderAbilitySteel * currentUpgradeLevel / GameController.TotalUpgrade;
                        turboNeed = KnightRiderAbilityTurbo * currentUpgradeLevel / GameController.TotalUpgrade;
                        break;
                }

                break;
        }
        
        return new Upgrade
        {
            _ammoNeed = ammoNeed,
            _brakeNeed = brakeNeed,
            _capsuleNeed = capsuleNeed,
            _gasolineNeed = gasolineNeed,
            _motorNeed = motorNeed,
            _steelNeed = steelNeed,
            _suspensionNeed = suspensionNeed,
            _turboNeed = turboNeed,
        };
    }
}