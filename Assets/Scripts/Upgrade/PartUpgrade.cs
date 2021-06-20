public class PartUpgrade
{
    /*
 *
 * Cars maximum and minimum values. If you want to x level power 
 * you will use (Maximum Value - Minimum Value) * x(Current Upgrade Level)
 * 
    */
    //--------------------------------------------------------------
    //Hatchback
    //Mass
    private static readonly float HatchbackMassMaximumValue = 1245;
    private static readonly float HatchbackMassMinimumValue = 1350;

    //Engine
    private static readonly float HatchbackMotorMaximumValue = 3325;
    private static readonly float HatchbackMotorMinimumValue = 1400;

    //Brake
    private static readonly float HatchbackBrakeMaximumValue = 2755;
    private static readonly float HatchbackBrakeMinimumValue = 1135;

    //Health
    private static readonly float HatchbackHealthMaximumValue = 220;
    private static readonly float HatchbackHealthMinimumValue = 45;

    //Fuel
    private static readonly float HatchbackFuelMaximumValue = 165;
    private static readonly float HatchbackFuelMinimumValue = 52.5F;

    //Durability
    private static readonly float HatchbackDurabilityMaximumValue = 260;
    private static readonly float HatchbackDurabilityMinimumValue = 50;

    //Boost Fuel
    private static readonly float HatchbackBoostFuelMaximumValue = 7.5F;
    private static readonly float HatchbackBoostFuelMinimumValue = 2.5F;

    //Boost Power
    private static readonly float HatchbackBoostPowerMaximumValue = 4825;
    private static readonly float HatchbackBoostPowerMinimumValue = 3250;

    //Fuel Consumption Idle
    private static readonly float HatchbackIdleFuelConsumptionMaximumValue = 0.675F;
    private static readonly float HatchbackIdleFuelConsumptionMinimumValue = 0.75F;

    //Fuel Consumption Gas
    private static readonly float HatchbackGasFuelConsumptionMaximumValue = 1.1F;
    private static readonly float HatchbackGasFuelConsumptionMinimumValue = 1.25F;

    //Boost Regen
    private static readonly float HatchbackBoostRegenMaximumValue = 0F;
    private static readonly float HatchbackBoostRegenMinimumValue = 0F;

    //Wheel Stiffness
    private static readonly float HatchbackWheelStiffnessMaximumValue = 3.6F;
    private static readonly float HatchbackWheelStiffnessMinimumValue = 2;

    //Ammo
    private static readonly int HatchbackAmmoMaximumValue = 20;
    private static readonly int HatchbackAmmoMinimumValue = 5;


    //Sedan
    //Mass
    private static readonly float SedanMassMaximumValue = 1135;
    private static readonly float SedanMassMinimumValue = 1275;

    //Engine
    private static readonly float SedanMotorMaximumValue = 3630;
    private static readonly float SedanMotorMinimumValue = 1500;

    //Brake
    private static readonly float SedanBrakeMaximumValue = 3000;
    private static readonly float SedanBrakeMinimumValue = 1215;

    //Health
    private static readonly float SedanHealthMaximumValue = 268;
    private static readonly float SedanHealthMinimumValue = 65;

    //Fuel
    private static readonly float SedanFuelMaximumValue = 195;
    private static readonly float SedanFuelMinimumValue = 70F;

    //Durability
    private static readonly float SedanDurabilityMaximumValue = 317;
    private static readonly float SedanDurabilityMinimumValue = 65;

    //Boost Fuel
    private static readonly float SedanBoostFuelMaximumValue = 8F;
    private static readonly float SedanBoostFuelMinimumValue = 3F;

    //Boost Power
    private static readonly float SedanBoostPowerMaximumValue = 5535;
    private static readonly float SedanBoostPowerMinimumValue = 3785;

    //Fuel Consumption Idle
    private static readonly float SedanIdleFuelConsumptionMaximumValue = 0.67F;
    private static readonly float SedanIdleFuelConsumptionMinimumValue = 0.73F;

    //Fuel Consumption Gas
    private static readonly float SedanGasFuelConsumptionMaximumValue = 1.08F;
    private static readonly float SedanGasFuelConsumptionMinimumValue = 1.22F;

    //Boost Regen
    private static readonly float SedanBoostRegenMaximumValue = 0F;
    private static readonly float SedanBoostRegenMinimumValue = 0F;

    //Wheel Stiffness
    private static readonly float SedanWheelStiffnessMaximumValue = 3.83F;
    private static readonly float SedanWheelStiffnessMinimumValue = 2.1F;

    //Ammo
    private static readonly int SedanAmmoMaximumValue = 45;
    private static readonly int SedanAmmoMinimumValue = 15;


    //Pickup
    //Mass
    private static readonly float PickupMassMaximumValue = 1020;
    private static readonly float PickupMassMinimumValue = 1300;

    //Engine
    private static readonly float PickupMotorMaximumValue = 3850;
    private static readonly float PickupMotorMinimumValue = 1650;

    //Brake
    private static readonly float PickupBrakeMaximumValue = 3300;
    private static readonly float PickupBrakeMinimumValue = 1585;

    //Health
    private static readonly float PickupHealthMaximumValue = 375;
    private static readonly float PickupHealthMinimumValue = 95;

    //Fuel
    private static readonly float PickupFuelMaximumValue = 215;
    private static readonly float PickupFuelMinimumValue = 85;

    //Durability
    private static readonly float PickupDurabilityMaximumValue = 327;
    private static readonly float PickupDurabilityMinimumValue = 75;

    //Boost Fuel
    private static readonly float PickupBoostFuelMaximumValue = 8.5F;
    private static readonly float PickupBoostFuelMinimumValue = 3.5F;

    //Boost Power
    private static readonly float PickupBoostPowerMaximumValue = 6350;
    private static readonly float PickupBoostPowerMinimumValue = 4250;

    //Fuel Consumption Idle
    private static readonly float PickupIdleFuelConsumptionMaximumValue = 0.6F;
    private static readonly float PickupIdleFuelConsumptionMinimumValue = 0.7F;

    //Fuel Consumption Gas
    private static readonly float PickupGasFuelConsumptionMaximumValue = 1.03F;
    private static readonly float PickupGasFuelConsumptionMinimumValue = 1.2F;

    //Boost Regen
    private static readonly float PickupBoostRegenMaximumValue = 0F;
    private static readonly float PickupBoostRegenMinimumValue = 0F;

    //Wheel Stiffness
    private static readonly float PickupWheelStiffnessMaximumValue = 3.925F;
    private static readonly float PickupWheelStiffnessMinimumValue = 2.15F;

    //Ammo
    private static readonly int PickupAmmoMaximumValue = 55;
    private static readonly int PickupAmmoMinimumValue = 20;


    //Bugee
    //Mass
    private static readonly float BugeeMassMaximumValue = 930;
    private static readonly float BugeeMassMinimumValue = 1000;

    //Engine
    private static readonly float BugeeMotorMaximumValue = 4000;
    private static readonly float BugeeMotorMinimumValue = 1500;

    //Brake
    private static readonly float BugeeBrakeMaximumValue = 3800;
    private static readonly float BugeeBrakeMinimumValue = 1500;

    //Health
    private static readonly float BugeeHealthMaximumValue = 260;
    private static readonly float BugeeHealthMinimumValue = 85;

    //Fuel
    private static readonly float BugeeFuelMaximumValue = 235;
    private static readonly float BugeeFuelMinimumValue = 100;

    //Durability
    private static readonly float BugeeDurabilityMaximumValue = 280;
    private static readonly float BugeeDurabilityMinimumValue = 70;

    //Boost Fuel
    private static readonly float BugeeBoostFuelMaximumValue = 9F;
    private static readonly float BugeeBoostFuelMinimumValue = 4F;

    //Boost Power
    private static readonly float BugeeBoostPowerMaximumValue = 6400;
    private static readonly float BugeeBoostPowerMinimumValue = 5000;

    //Fuel Consumption Idle
    private static readonly float BugeeIdleFuelConsumptionMaximumValue = 0.58F;
    private static readonly float BugeeIdleFuelConsumptionMinimumValue = 0.68F;

    //Fuel Consumption Gas
    private static readonly float BugeeGasFuelConsumptionMaximumValue = 1F;
    private static readonly float BugeeGasFuelConsumptionMinimumValue = 1.15F;

    //Boost Regen
    private static readonly float BugeeBoostRegenMaximumValue = 0.1F;
    private static readonly float BugeeBoostRegenMinimumValue = 0F;

    //Wheel Stiffness
    private static readonly float BugeeWheelStiffnessMaximumValue = 4.025F;
    private static readonly float BugeeWheelStiffnessMinimumValue = 2.25F;

    //Ammo
    private static readonly int BugeeAmmoMaximumValue = 60;
    private static readonly int BugeeAmmoMinimumValue = 25;


    //Military
    //Mass
    private static readonly float MilitaryMassMaximumValue = 1450;
    private static readonly float MilitaryMassMinimumValue = 1750;

    //Engine
    private static readonly float MilitaryMotorMaximumValue = 5000;
    private static readonly float MilitaryMotorMinimumValue = 2075;

    //Brake
    private static readonly float MilitaryBrakeMaximumValue = 4950;
    private static readonly float MilitaryBrakeMinimumValue = 2125;

    //Health
    private static readonly float MilitaryHealthMaximumValue = 600;
    private static readonly float MilitaryHealthMinimumValue = 250;

    //Fuel
    private static readonly float MilitaryFuelMaximumValue = 315;
    private static readonly float MilitaryFuelMinimumValue = 115;

    //Durability
    private static readonly float MilitaryDurabilityMaximumValue = 945;
    private static readonly float MilitaryDurabilityMinimumValue = 350;

    //Boost Fuel
    private static readonly float MilitaryBoostFuelMaximumValue = 9.5F;
    private static readonly float MilitaryBoostFuelMinimumValue = 4.5F;

    //Boost Power
    private static readonly float MilitaryBoostPowerMaximumValue = 8000;
    private static readonly float MilitaryBoostPowerMinimumValue = 5050;

    //Fuel Consumption Idle
    private static readonly float MilitaryIdleFuelConsumptionMaximumValue = 0.55F;
    private static readonly float MilitaryIdleFuelConsumptionMinimumValue = 0.64F;

    //Fuel Consumption Gas
    private static readonly float MilitaryGasFuelConsumptionMaximumValue = 0.95F;
    private static readonly float MilitaryGasFuelConsumptionMinimumValue = 1.11F;

    //Boost Regen
    private static readonly float MilitaryBoostRegenMaximumValue = 0.244F;
    private static readonly float MilitaryBoostRegenMinimumValue = 0.125F;

    //Wheel Stiffness
    private static readonly float MilitaryWheelStiffnessMaximumValue = 4.1F;
    private static readonly float MilitaryWheelStiffnessMinimumValue = 2.35F;

    //Ammo
    private static readonly int MilitaryAmmoMaximumValue = 80;
    private static readonly int MilitaryAmmoMinimumValue = 30;


    //Fustang
    //Mass
    private static readonly float FustangMassMaximumValue = 890;
    private static readonly float FustangMassMinimumValue = 1015;

    //Engine
    private static readonly float FustangMotorMaximumValue = 4200;
    private static readonly float FustangMotorMinimumValue = 1750;

    //Brake
    private static readonly float FustangBrakeMaximumValue = 3625;
    private static readonly float FustangBrakeMinimumValue = 1375;

    //Health
    private static readonly float FustangHealthMaximumValue = 372.5F;
    private static readonly float FustangHealthMinimumValue = 75;

    //Fuel
    private static readonly float FustangFuelMaximumValue = 300;
    private static readonly float FustangFuelMinimumValue = 130;

    //Durability
    private static readonly float FustangDurabilityMaximumValue = 665;
    private static readonly float FustangDurabilityMinimumValue = 200;

    //Boost Fuel
    private static readonly float FustangBoostFuelMaximumValue = 11F;
    private static readonly float FustangBoostFuelMinimumValue = 5F;

    //Boost Power
    private static readonly float FustangBoostPowerMaximumValue = 7500;
    private static readonly float FustangBoostPowerMinimumValue = 4500;

    //Fuel Consumption Idle
    private static readonly float FustangIdleFuelConsumptionMaximumValue = 0.52F;
    private static readonly float FustangIdleFuelConsumptionMinimumValue = 0.6F;

    //Fuel Consumption Gas
    private static readonly float FustangGasFuelConsumptionMaximumValue = 0.85F;
    private static readonly float FustangGasFuelConsumptionMinimumValue = 1.05F;

    //Boost Regen
    private static readonly float FustangBoostRegenMaximumValue = 0.35F;
    private static readonly float FustangBoostRegenMinimumValue = 0.13F;

    //Wheel Stiffness
    private static readonly float FustangWheelStiffnessMaximumValue = 4F;
    private static readonly float FustangWheelStiffnessMinimumValue = 2.5F;

    //Ammo
    private static readonly int FustangAmmoMaximumValue = 85;
    private static readonly int FustangAmmoMinimumValue = 30;

    //Ability Time
    private static readonly float FustangAbilityTimeMaximumValue = 100;
    private static readonly float FustangAbilityTimeMinimumValue = 135;

    //Ability Power
    private static readonly float FustangAbilityPowerMaximumValue = 120;
    private static readonly float FustangAbilityPowerMinimumValue = 50;


    //KnightRider
    //Mass
    private static readonly float KnightRiderMassMaximumValue = 825;
    private static readonly float KnightRiderMassMinimumValue = 985;

    //Engine
    private static readonly float KnightRiderMotorMaximumValue = 5200;
    private static readonly float KnightRiderMotorMinimumValue = 2250;

    //Brake
    private static readonly float KnightRiderBrakeMaximumValue = 5200;
    private static readonly float KnightRiderBrakeMinimumValue = 1825;

    //Health
    private static readonly float KnightRiderHealthMaximumValue = 417.5F;
    private static readonly float KnightRiderHealthMinimumValue = 85;

    //Fuel
    private static readonly float KnightRiderFuelMaximumValue = 350;
    private static readonly float KnightRiderFuelMinimumValue = 145;

    //Durability
    private static readonly float KnightRiderDurabilityMaximumValue = 815;
    private static readonly float KnightRiderDurabilityMinimumValue = 325;

    //Boost Fuel
    private static readonly float KnightRiderBoostFuelMaximumValue = 15F;
    private static readonly float KnightRiderBoostFuelMinimumValue = 6F;

    //Boost Power
    private static readonly float KnightRiderBoostPowerMaximumValue = 8100;
    private static readonly float KnightRiderBoostPowerMinimumValue = 5000;

    //Fuel Consumption Idle
    private static readonly float KnightRiderIdleFuelConsumptionMaximumValue = 0.4F;
    private static readonly float KnightRiderIdleFuelConsumptionMinimumValue = 0.5F;

    //Fuel Consumption Gas
    private static readonly float KnightRiderGasFuelConsumptionMaximumValue = 0.8F;
    private static readonly float KnightRiderGasFuelConsumptionMinimumValue = 0.95F;

    //Boost Regen
    private static readonly float KnightRiderBoostRegenMaximumValue = 0.455F;
    private static readonly float KnightRiderBoostRegenMinimumValue = 0.15F;

    //Wheel Stiffness
    private static readonly float KnightRiderWheelStiffnessMaximumValue = 4.1F;
    private static readonly float KnightRiderWheelStiffnessMinimumValue = 2.6F;

    //Ammo
    private static readonly int KnightRiderAmmoMaximumValue = 92;
    private static readonly int KnightRiderAmmoMinimumValue = 32;

    //Ability Time
    private static readonly float KnightRiderAbilityTimeMaximumValue = 3.875F;
    private static readonly float KnightRiderAbilityTimeMinimumValue = 10;

    //Ability Power
    private static readonly float KnightRiderAbilityPowerMaximumValue = 30F;
    private static readonly float KnightRiderAbilityPowerMinimumValue = 22.5F;

    //--------------------------------------------------------------

    //Mass

    public float MassMaximumValue;

    public float MassMinimumValue;
    //Engine

    public float EngineMaximumValue;

    public float EngineMinimumValue;
    //Brake

    public float BrakeMaximumValue;

    public float BrakeMinimumValue;
    //Health

    public float HealthMaximumValue;

    public float HealthMinimumValue;
    //Fuel

    public float FuelMaximumValue;

    public float FuelMinimumValue;
    //Durability

    public float DurabilityMaximumValue;

    public float DurabilityMinimumValue;
    //Boost Fuel

    public float BoostFuelMaximumValue;

    public float BoostFuelMinimumValue;
    //Boost Power

    public float BoostPowerMaximumValue;

    public float BoostPowerMinimumValue;
    //Fuel Consumption Idle

    public float FuelConsumptionIdleMaximumValue;

    public float FuelConsumptionIdleMinimumValue;
    //Fuel Consumption Gas

    public float FuelConsumptionGasMaximumValue;

    public float FuelConsumptionGasMinimumValue;
    //Boost Regen

    public float BoostRegenMaximumValue;

    public float BoostRegenMinimumValue;
    //Wheel Stiffness

    public float WheelStiffnessMaximumValue;

    public float WheelStiffnessMinimumValue;
    //Ammo

    public int AmmoMaximumValue;

    public int AmmoMinimumValue;
    //Ability Time

    public float AbilityTimeMaximumValue;

    public float AbilityTimeMinimumValue;
    //Ability Power

    public float AbilityPowerMaximumValue;

    public float AbilityPowerMinimumValue;


    public float AbilityPower =>
        (AbilityPowerMaximumValue - AbilityPowerMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Ability) / GameController.TotalUpgrade;

    public float AbilityTime =>
        (AbilityTimeMinimumValue - AbilityTimeMaximumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Ability) / GameController.TotalUpgrade;

    public int Ammo =>
        (AmmoMaximumValue - AmmoMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Gun) / GameController.TotalUpgrade;

    public float WheelStiffness =>
        (WheelStiffnessMaximumValue - WheelStiffnessMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Brake) / GameController.TotalUpgrade;

    public float BoostRegen =>
        (BoostRegenMaximumValue - BoostRegenMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Boost) / GameController.TotalUpgrade;

    public float FuelConsumptionIdle =>
        (FuelConsumptionIdleMinimumValue - FuelConsumptionIdleMaximumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Fuel) / GameController.TotalUpgrade;

    public float FuelConsumptionGas =>
        (FuelConsumptionGasMinimumValue - FuelConsumptionGasMaximumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Fuel) / GameController.TotalUpgrade;

    public float BoostPower =>
        (BoostPowerMaximumValue - BoostPowerMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Boost) / GameController.TotalUpgrade;

    public float BoostFuel =>
        (BoostFuelMaximumValue - BoostFuelMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Boost) / GameController.TotalUpgrade;

    public float Durability =>
        (DurabilityMaximumValue - DurabilityMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Durability) / GameController.TotalUpgrade;

    public float Fuel =>
        (FuelMaximumValue - FuelMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Fuel) / GameController.TotalUpgrade;

    public float Health =>
        (HealthMaximumValue - HealthMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Durability) / GameController.TotalUpgrade;

    public float Brake =>
        (BrakeMaximumValue - BrakeMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Brake) / GameController.TotalUpgrade;

    public float Engine =>
        (EngineMaximumValue - EngineMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Engine) / GameController.TotalUpgrade;

    public float Mass =>
        (MassMinimumValue - MassMaximumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Gun) / GameController.TotalUpgrade;


    public static PartUpgrade GetPartUpgrade()
    {
        switch (GameController.GetCurrentCar)
        {
            case Vehicles.Sedan:
                return new PartUpgrade
                {
                    AmmoMaximumValue = SedanAmmoMaximumValue,
                    AmmoMinimumValue = SedanAmmoMinimumValue,
                    BrakeMaximumValue = SedanBrakeMaximumValue,
                    BrakeMinimumValue = SedanBrakeMinimumValue,
                    DurabilityMaximumValue = SedanDurabilityMaximumValue,
                    DurabilityMinimumValue = SedanDurabilityMinimumValue,
                    EngineMaximumValue = SedanMotorMaximumValue,
                    EngineMinimumValue = SedanMotorMinimumValue,
                    FuelMaximumValue = SedanFuelMaximumValue,
                    FuelMinimumValue = SedanFuelMinimumValue,
                    HealthMaximumValue = SedanHealthMaximumValue,
                    HealthMinimumValue = SedanHealthMinimumValue,
                    MassMaximumValue = SedanMassMaximumValue,
                    MassMinimumValue = SedanMassMinimumValue,
                    BoostFuelMaximumValue = SedanBoostFuelMaximumValue,
                    BoostFuelMinimumValue = SedanBoostFuelMinimumValue,
                    FuelConsumptionIdleMinimumValue = SedanIdleFuelConsumptionMinimumValue,
                    FuelConsumptionIdleMaximumValue = SedanIdleFuelConsumptionMaximumValue,
                    FuelConsumptionGasMaximumValue = SedanGasFuelConsumptionMaximumValue,
                    FuelConsumptionGasMinimumValue = SedanGasFuelConsumptionMinimumValue,
                    BoostPowerMaximumValue = SedanBoostPowerMaximumValue,
                    BoostPowerMinimumValue = SedanBoostPowerMinimumValue,
                    BoostRegenMaximumValue = SedanBoostRegenMaximumValue,
                    BoostRegenMinimumValue = SedanBoostRegenMinimumValue,
                    WheelStiffnessMaximumValue = SedanWheelStiffnessMaximumValue,
                    WheelStiffnessMinimumValue = SedanWheelStiffnessMinimumValue,
                    AbilityPowerMaximumValue = 0,
                    AbilityPowerMinimumValue = 0,
                    AbilityTimeMaximumValue = 0,
                    AbilityTimeMinimumValue = 0,
                };
            case Vehicles.Pickup:
                return new PartUpgrade
                {
                    AmmoMaximumValue = PickupAmmoMaximumValue,
                    AmmoMinimumValue = PickupAmmoMinimumValue,
                    BrakeMaximumValue = PickupBrakeMaximumValue,
                    BrakeMinimumValue = PickupBrakeMinimumValue,
                    DurabilityMaximumValue = PickupDurabilityMaximumValue,
                    DurabilityMinimumValue = PickupDurabilityMinimumValue,
                    EngineMaximumValue = PickupMotorMaximumValue,
                    EngineMinimumValue = PickupMotorMinimumValue,
                    FuelMaximumValue = PickupFuelMaximumValue,
                    FuelMinimumValue = PickupFuelMinimumValue,
                    HealthMaximumValue = PickupHealthMaximumValue,
                    HealthMinimumValue = PickupHealthMinimumValue,
                    MassMaximumValue = PickupMassMaximumValue,
                    MassMinimumValue = PickupMassMinimumValue,
                    BoostFuelMaximumValue = PickupBoostFuelMaximumValue,
                    BoostFuelMinimumValue = PickupBoostFuelMinimumValue,
                    FuelConsumptionIdleMinimumValue = PickupIdleFuelConsumptionMinimumValue,
                    FuelConsumptionIdleMaximumValue = PickupIdleFuelConsumptionMaximumValue,
                    FuelConsumptionGasMaximumValue = PickupGasFuelConsumptionMaximumValue,
                    FuelConsumptionGasMinimumValue = PickupGasFuelConsumptionMinimumValue,
                    BoostPowerMaximumValue = PickupBoostPowerMaximumValue,
                    BoostPowerMinimumValue = PickupBoostPowerMinimumValue,
                    BoostRegenMaximumValue = PickupBoostRegenMaximumValue,
                    BoostRegenMinimumValue = PickupBoostRegenMinimumValue,
                    WheelStiffnessMaximumValue = PickupWheelStiffnessMaximumValue,
                    WheelStiffnessMinimumValue = PickupWheelStiffnessMinimumValue,
                    AbilityPowerMaximumValue = 0,
                    AbilityPowerMinimumValue = 0,
                    AbilityTimeMaximumValue = 0,
                    AbilityTimeMinimumValue = 0,
                };
            case Vehicles.Bugee:
                return new PartUpgrade
                {
                    AmmoMaximumValue = BugeeAmmoMaximumValue,
                    AmmoMinimumValue = BugeeAmmoMinimumValue,
                    BrakeMaximumValue = BugeeBrakeMaximumValue,
                    BrakeMinimumValue = BugeeBrakeMinimumValue,
                    DurabilityMaximumValue = BugeeDurabilityMaximumValue,
                    DurabilityMinimumValue = BugeeDurabilityMinimumValue,
                    EngineMaximumValue = BugeeMotorMaximumValue,
                    EngineMinimumValue = BugeeMotorMinimumValue,
                    FuelMaximumValue = BugeeFuelMaximumValue,
                    FuelMinimumValue = BugeeFuelMinimumValue,
                    HealthMaximumValue = BugeeHealthMaximumValue,
                    HealthMinimumValue = BugeeHealthMinimumValue,
                    MassMaximumValue = BugeeMassMaximumValue,
                    MassMinimumValue = BugeeMassMinimumValue,
                    BoostFuelMaximumValue = BugeeBoostFuelMaximumValue,
                    BoostFuelMinimumValue = BugeeBoostFuelMinimumValue,
                    FuelConsumptionIdleMinimumValue = BugeeIdleFuelConsumptionMinimumValue,
                    FuelConsumptionIdleMaximumValue = BugeeIdleFuelConsumptionMaximumValue,
                    FuelConsumptionGasMaximumValue = BugeeGasFuelConsumptionMaximumValue,
                    FuelConsumptionGasMinimumValue = BugeeGasFuelConsumptionMinimumValue,
                    BoostPowerMaximumValue = BugeeBoostPowerMaximumValue,
                    BoostPowerMinimumValue = BugeeBoostPowerMinimumValue,
                    BoostRegenMaximumValue = BugeeBoostRegenMaximumValue,
                    BoostRegenMinimumValue = BugeeBoostRegenMinimumValue,
                    WheelStiffnessMaximumValue = BugeeWheelStiffnessMaximumValue,
                    WheelStiffnessMinimumValue = BugeeWheelStiffnessMinimumValue,
                    AbilityPowerMaximumValue = 0,
                    AbilityPowerMinimumValue = 0,
                    AbilityTimeMaximumValue = 0,
                    AbilityTimeMinimumValue = 0,
                };
            case Vehicles.Military6X6:
                return new PartUpgrade
                {
                    AmmoMaximumValue = MilitaryAmmoMaximumValue,
                    AmmoMinimumValue = MilitaryAmmoMinimumValue,
                    BrakeMaximumValue = MilitaryBrakeMaximumValue,
                    BrakeMinimumValue = MilitaryBrakeMinimumValue,
                    DurabilityMaximumValue = MilitaryDurabilityMaximumValue,
                    DurabilityMinimumValue = MilitaryDurabilityMinimumValue,
                    EngineMaximumValue = MilitaryMotorMaximumValue,
                    EngineMinimumValue = MilitaryMotorMinimumValue,
                    FuelMaximumValue = MilitaryFuelMaximumValue,
                    FuelMinimumValue = MilitaryFuelMinimumValue,
                    HealthMaximumValue = MilitaryHealthMaximumValue,
                    HealthMinimumValue = MilitaryHealthMinimumValue,
                    MassMaximumValue = MilitaryMassMaximumValue,
                    MassMinimumValue = MilitaryMassMinimumValue,
                    BoostFuelMaximumValue = MilitaryBoostFuelMaximumValue,
                    BoostFuelMinimumValue = MilitaryBoostFuelMinimumValue,
                    FuelConsumptionIdleMinimumValue = MilitaryIdleFuelConsumptionMinimumValue,
                    FuelConsumptionIdleMaximumValue = MilitaryIdleFuelConsumptionMaximumValue,
                    FuelConsumptionGasMaximumValue = MilitaryGasFuelConsumptionMaximumValue,
                    FuelConsumptionGasMinimumValue = MilitaryGasFuelConsumptionMinimumValue,
                    BoostPowerMaximumValue = MilitaryBoostPowerMaximumValue,
                    BoostPowerMinimumValue = MilitaryBoostPowerMinimumValue,
                    BoostRegenMaximumValue = MilitaryBoostRegenMaximumValue,
                    BoostRegenMinimumValue = MilitaryBoostRegenMinimumValue,
                    WheelStiffnessMaximumValue = MilitaryWheelStiffnessMaximumValue,
                    WheelStiffnessMinimumValue = MilitaryWheelStiffnessMinimumValue,
                    AbilityPowerMaximumValue = 0,
                    AbilityPowerMinimumValue = 0,
                    AbilityTimeMaximumValue = 0,
                    AbilityTimeMinimumValue = 0,
                };
            case Vehicles.Fustang:
                return new PartUpgrade
                {
                    AmmoMaximumValue = FustangAmmoMaximumValue,
                    AmmoMinimumValue = FustangAmmoMinimumValue,
                    BrakeMaximumValue = FustangBrakeMaximumValue,
                    BrakeMinimumValue = FustangBrakeMinimumValue,
                    DurabilityMaximumValue = FustangDurabilityMaximumValue,
                    DurabilityMinimumValue = FustangDurabilityMinimumValue,
                    EngineMaximumValue = FustangMotorMaximumValue,
                    EngineMinimumValue = FustangMotorMinimumValue,
                    FuelMaximumValue = FustangFuelMaximumValue,
                    FuelMinimumValue = FustangFuelMinimumValue,
                    HealthMaximumValue = FustangHealthMaximumValue,
                    HealthMinimumValue = FustangHealthMinimumValue,
                    MassMaximumValue = FustangMassMaximumValue,
                    MassMinimumValue = FustangMassMinimumValue,
                    BoostFuelMaximumValue = FustangBoostFuelMaximumValue,
                    BoostFuelMinimumValue = FustangBoostFuelMinimumValue,
                    FuelConsumptionIdleMinimumValue = FustangIdleFuelConsumptionMinimumValue,
                    FuelConsumptionIdleMaximumValue = FustangIdleFuelConsumptionMaximumValue,
                    FuelConsumptionGasMaximumValue = FustangGasFuelConsumptionMaximumValue,
                    FuelConsumptionGasMinimumValue = FustangGasFuelConsumptionMinimumValue,
                    BoostPowerMaximumValue = FustangBoostPowerMaximumValue,
                    BoostPowerMinimumValue = FustangBoostPowerMinimumValue,
                    BoostRegenMaximumValue = FustangBoostRegenMaximumValue,
                    BoostRegenMinimumValue = FustangBoostRegenMinimumValue,
                    WheelStiffnessMaximumValue = FustangWheelStiffnessMaximumValue,
                    WheelStiffnessMinimumValue = FustangWheelStiffnessMinimumValue,
                    AbilityPowerMaximumValue = FustangAbilityPowerMaximumValue,
                    AbilityPowerMinimumValue = FustangAbilityPowerMinimumValue,
                    AbilityTimeMaximumValue = FustangAbilityTimeMaximumValue,
                    AbilityTimeMinimumValue = FustangAbilityTimeMinimumValue,
                };
            case Vehicles.KnightRider:
                return new PartUpgrade
                {
                    AmmoMaximumValue = KnightRiderAmmoMaximumValue,
                    AmmoMinimumValue = KnightRiderAmmoMinimumValue,
                    BrakeMaximumValue = KnightRiderBrakeMaximumValue,
                    BrakeMinimumValue = KnightRiderBrakeMinimumValue,
                    DurabilityMaximumValue = KnightRiderDurabilityMaximumValue,
                    DurabilityMinimumValue = KnightRiderDurabilityMinimumValue,
                    EngineMaximumValue = KnightRiderMotorMaximumValue,
                    EngineMinimumValue = KnightRiderMotorMinimumValue,
                    FuelMaximumValue = KnightRiderFuelMaximumValue,
                    FuelMinimumValue = KnightRiderFuelMinimumValue,
                    HealthMaximumValue = KnightRiderHealthMaximumValue,
                    HealthMinimumValue = KnightRiderHealthMinimumValue,
                    MassMaximumValue = KnightRiderMassMaximumValue,
                    MassMinimumValue = KnightRiderMassMinimumValue,
                    BoostFuelMaximumValue = KnightRiderBoostFuelMaximumValue,
                    BoostFuelMinimumValue = KnightRiderBoostFuelMinimumValue,
                    FuelConsumptionIdleMinimumValue = KnightRiderIdleFuelConsumptionMinimumValue,
                    FuelConsumptionIdleMaximumValue = KnightRiderIdleFuelConsumptionMaximumValue,
                    FuelConsumptionGasMaximumValue = KnightRiderGasFuelConsumptionMaximumValue,
                    FuelConsumptionGasMinimumValue = KnightRiderGasFuelConsumptionMinimumValue,
                    BoostPowerMaximumValue = KnightRiderBoostPowerMaximumValue,
                    BoostPowerMinimumValue = KnightRiderBoostPowerMinimumValue,
                    BoostRegenMaximumValue = KnightRiderBoostRegenMaximumValue,
                    BoostRegenMinimumValue = KnightRiderBoostRegenMinimumValue,
                    WheelStiffnessMaximumValue = KnightRiderWheelStiffnessMaximumValue,
                    WheelStiffnessMinimumValue = KnightRiderWheelStiffnessMinimumValue,
                    AbilityPowerMaximumValue = KnightRiderAbilityPowerMaximumValue,
                    AbilityPowerMinimumValue = KnightRiderAbilityPowerMinimumValue,
                    AbilityTimeMaximumValue = KnightRiderAbilityTimeMaximumValue,
                    AbilityTimeMinimumValue = KnightRiderAbilityTimeMinimumValue,
                };
            default:
                return new PartUpgrade
                {
                    AmmoMaximumValue = HatchbackAmmoMaximumValue,
                    AmmoMinimumValue = HatchbackAmmoMinimumValue,
                    BrakeMaximumValue = HatchbackBrakeMaximumValue,
                    BrakeMinimumValue = HatchbackBrakeMinimumValue,
                    DurabilityMaximumValue = HatchbackDurabilityMaximumValue,
                    DurabilityMinimumValue = HatchbackDurabilityMinimumValue,
                    EngineMaximumValue = HatchbackMotorMaximumValue,
                    EngineMinimumValue = HatchbackMotorMinimumValue,
                    FuelMaximumValue = HatchbackFuelMaximumValue,
                    FuelMinimumValue = HatchbackFuelMinimumValue,
                    HealthMaximumValue = HatchbackHealthMaximumValue,
                    HealthMinimumValue = HatchbackHealthMinimumValue,
                    MassMaximumValue = HatchbackMassMaximumValue,
                    MassMinimumValue = HatchbackMassMinimumValue,
                    BoostFuelMaximumValue = HatchbackBoostFuelMaximumValue,
                    BoostFuelMinimumValue = HatchbackBoostFuelMinimumValue,
                    FuelConsumptionIdleMinimumValue = HatchbackIdleFuelConsumptionMinimumValue,
                    FuelConsumptionIdleMaximumValue = HatchbackIdleFuelConsumptionMaximumValue,
                    FuelConsumptionGasMaximumValue = HatchbackGasFuelConsumptionMaximumValue,
                    FuelConsumptionGasMinimumValue = HatchbackGasFuelConsumptionMinimumValue,
                    BoostPowerMaximumValue = HatchbackBoostPowerMaximumValue,
                    BoostPowerMinimumValue = HatchbackBoostPowerMinimumValue,
                    BoostRegenMaximumValue = HatchbackBoostRegenMaximumValue,
                    BoostRegenMinimumValue = HatchbackBoostRegenMinimumValue,
                    WheelStiffnessMaximumValue = HatchbackWheelStiffnessMaximumValue,
                    WheelStiffnessMinimumValue = HatchbackWheelStiffnessMinimumValue,
                    AbilityPowerMaximumValue = 0,
                    AbilityPowerMinimumValue = 0,
                    AbilityTimeMaximumValue = 0,
                    AbilityTimeMinimumValue = 0,
                };
        }
    }
}