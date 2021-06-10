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

    private float _massMaximumValue;

    private float _massMinimumValue;
    //Engine

    private float _engineMaximumValue;

    private float _engineMinimumValue;
    //Brake

    private float _brakeMaximumValue;

    private float _brakeMinimumValue;
    //Health

    private float _healthMaximumValue;

    private float _healthMinimumValue;
    //Fuel

    private float _fuelMaximumValue;

    private float _fuelMinimumValue;
    //Durability

    private float _durabilityMaximumValue;

    private float _durabilityMinimumValue;
    //Boost Fuel

    private float _boostFuelMaximumValue;

    private float _boostFuelMinimumValue;
    //Boost Power

    private float _boostPowerMaximumValue;

    private float _boostPowerMinimumValue;
    //Fuel Consumption Idle

    private float _fuelConsumptionIdleMaximumValue;

    private float _fuelConsumptionIdleMinimumValue;
    //Fuel Consumption Gas

    private float _fuelConsumptionGasMaximumValue;

    private float _fuelConsumptionGasMinimumValue;
    //Boost Regen

    private float _boostRegenMaximumValue;

    private float _boostRegenMinimumValue;
    //Wheel Stiffness

    private float _wheelStiffnessMaximumValue;

    private float _wheelStiffnessMinimumValue;
    //Ammo

    private int _ammoMaximumValue;

    private int _ammoMinimumValue;
    //Ability Time

    private float _abilityTimeMaximumValue;

    private float _abilityTimeMinimumValue;
    //Ability Power

    private float _abilityPowerMaximumValue;

    private float _abilityPowerMinimumValue;


    public float AbilityPower =>
        (_abilityPowerMaximumValue - _abilityPowerMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Ability) / GameController.TotalUpgrade;

    public float AbilityTime =>
        (_abilityTimeMinimumValue - _abilityTimeMaximumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Ability) / GameController.TotalUpgrade;

    public int Ammo =>
        (_ammoMaximumValue - _ammoMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Gun) / GameController.TotalUpgrade;

    public float WheelStiffness =>
        (_wheelStiffnessMaximumValue - _wheelStiffnessMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Brake) / GameController.TotalUpgrade;

    public float BoostRegen =>
        (_boostRegenMaximumValue - _boostRegenMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Boost) / GameController.TotalUpgrade;

    public float FuelConsumptionIdle =>
        (_fuelConsumptionIdleMinimumValue - _fuelConsumptionIdleMaximumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Fuel) / GameController.TotalUpgrade;

    public float FuelConsumptionGas =>
        (_fuelConsumptionGasMinimumValue - _fuelConsumptionGasMaximumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Fuel) / GameController.TotalUpgrade;

    public float BoostPower =>
        (_boostPowerMaximumValue - _boostPowerMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Boost) / GameController.TotalUpgrade;

    public float BoostFuel =>
        (_boostFuelMaximumValue - _boostFuelMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Boost) / GameController.TotalUpgrade;

    public float Durability =>
        (_durabilityMaximumValue - _durabilityMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Durability) / GameController.TotalUpgrade;

    public float Fuel =>
        (_fuelMaximumValue - _fuelMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Fuel) / GameController.TotalUpgrade;

    public float Health =>
        (_healthMaximumValue - _healthMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Durability) / GameController.TotalUpgrade;

    public float Brake =>
        (_brakeMaximumValue - _brakeMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Brake) / GameController.TotalUpgrade;

    public float Engine =>
        (_engineMaximumValue - _engineMinimumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Engine) / GameController.TotalUpgrade;

    public float Mass =>
        (_massMinimumValue - _massMaximumValue) *
        GameController.GetCurrentUpgradeLevel(UpgradeType.Gun) / GameController.TotalUpgrade;


    public static PartUpgrade GetPartUpgrade()
    {
        switch (GameController.GetCurrentCar)
        {
            case Vehicles.Sedan:
                return new PartUpgrade
                {
                    _ammoMaximumValue = SedanAmmoMaximumValue,
                    _ammoMinimumValue = SedanAmmoMinimumValue,
                    _brakeMaximumValue = SedanBrakeMaximumValue,
                    _brakeMinimumValue = SedanBrakeMinimumValue,
                    _durabilityMaximumValue = SedanDurabilityMaximumValue,
                    _durabilityMinimumValue = SedanDurabilityMinimumValue,
                    _engineMaximumValue = SedanMotorMaximumValue,
                    _engineMinimumValue = SedanMotorMinimumValue,
                    _fuelMaximumValue = SedanFuelMaximumValue,
                    _fuelMinimumValue = SedanFuelMinimumValue,
                    _healthMaximumValue = SedanHealthMaximumValue,
                    _healthMinimumValue = SedanHealthMinimumValue,
                    _massMaximumValue = SedanMassMaximumValue,
                    _massMinimumValue = SedanMassMinimumValue,
                    _boostFuelMaximumValue = SedanBoostFuelMaximumValue,
                    _boostFuelMinimumValue = SedanBoostFuelMinimumValue,
                    _fuelConsumptionIdleMinimumValue = SedanIdleFuelConsumptionMinimumValue,
                    _fuelConsumptionIdleMaximumValue = SedanIdleFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMaximumValue = SedanGasFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMinimumValue = SedanGasFuelConsumptionMinimumValue,
                    _boostPowerMaximumValue = SedanBoostPowerMaximumValue,
                    _boostPowerMinimumValue = SedanBoostPowerMinimumValue,
                    _boostRegenMaximumValue = SedanBoostRegenMaximumValue,
                    _boostRegenMinimumValue = SedanBoostRegenMinimumValue,
                    _wheelStiffnessMaximumValue = SedanWheelStiffnessMaximumValue,
                    _wheelStiffnessMinimumValue = SedanWheelStiffnessMinimumValue,
                    _abilityPowerMaximumValue = 0,
                    _abilityPowerMinimumValue = 0,
                    _abilityTimeMaximumValue = 0,
                    _abilityTimeMinimumValue = 0,
                };
            case Vehicles.Pickup:
                return new PartUpgrade
                {
                    _ammoMaximumValue = PickupAmmoMaximumValue,
                    _ammoMinimumValue = PickupAmmoMinimumValue,
                    _brakeMaximumValue = PickupBrakeMaximumValue,
                    _brakeMinimumValue = PickupBrakeMinimumValue,
                    _durabilityMaximumValue = PickupDurabilityMaximumValue,
                    _durabilityMinimumValue = PickupDurabilityMinimumValue,
                    _engineMaximumValue = PickupMotorMaximumValue,
                    _engineMinimumValue = PickupMotorMinimumValue,
                    _fuelMaximumValue = PickupFuelMaximumValue,
                    _fuelMinimumValue = PickupFuelMinimumValue,
                    _healthMaximumValue = PickupHealthMaximumValue,
                    _healthMinimumValue = PickupHealthMinimumValue,
                    _massMaximumValue = PickupMassMaximumValue,
                    _massMinimumValue = PickupMassMinimumValue,
                    _boostFuelMaximumValue = PickupBoostFuelMaximumValue,
                    _boostFuelMinimumValue = PickupBoostFuelMinimumValue,
                    _fuelConsumptionIdleMinimumValue = PickupIdleFuelConsumptionMinimumValue,
                    _fuelConsumptionIdleMaximumValue = PickupIdleFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMaximumValue = PickupGasFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMinimumValue = PickupGasFuelConsumptionMinimumValue,
                    _boostPowerMaximumValue = PickupBoostPowerMaximumValue,
                    _boostPowerMinimumValue = PickupBoostPowerMinimumValue,
                    _boostRegenMaximumValue = PickupBoostRegenMaximumValue,
                    _boostRegenMinimumValue = PickupBoostRegenMinimumValue,
                    _wheelStiffnessMaximumValue = PickupWheelStiffnessMaximumValue,
                    _wheelStiffnessMinimumValue = PickupWheelStiffnessMinimumValue,
                    _abilityPowerMaximumValue = 0,
                    _abilityPowerMinimumValue = 0,
                    _abilityTimeMaximumValue = 0,
                    _abilityTimeMinimumValue = 0,
                };
            case Vehicles.Bugee:
                return new PartUpgrade
                {
                    _ammoMaximumValue = BugeeAmmoMaximumValue,
                    _ammoMinimumValue = BugeeAmmoMinimumValue,
                    _brakeMaximumValue = BugeeBrakeMaximumValue,
                    _brakeMinimumValue = BugeeBrakeMinimumValue,
                    _durabilityMaximumValue = BugeeDurabilityMaximumValue,
                    _durabilityMinimumValue = BugeeDurabilityMinimumValue,
                    _engineMaximumValue = BugeeMotorMaximumValue,
                    _engineMinimumValue = BugeeMotorMinimumValue,
                    _fuelMaximumValue = BugeeFuelMaximumValue,
                    _fuelMinimumValue = BugeeFuelMinimumValue,
                    _healthMaximumValue = BugeeHealthMaximumValue,
                    _healthMinimumValue = BugeeHealthMinimumValue,
                    _massMaximumValue = BugeeMassMaximumValue,
                    _massMinimumValue = BugeeMassMinimumValue,
                    _boostFuelMaximumValue = BugeeBoostFuelMaximumValue,
                    _boostFuelMinimumValue = BugeeBoostFuelMinimumValue,
                    _fuelConsumptionIdleMinimumValue = BugeeIdleFuelConsumptionMinimumValue,
                    _fuelConsumptionIdleMaximumValue = BugeeIdleFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMaximumValue = BugeeGasFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMinimumValue = BugeeGasFuelConsumptionMinimumValue,
                    _boostPowerMaximumValue = BugeeBoostPowerMaximumValue,
                    _boostPowerMinimumValue = BugeeBoostPowerMinimumValue,
                    _boostRegenMaximumValue = BugeeBoostRegenMaximumValue,
                    _boostRegenMinimumValue = BugeeBoostRegenMinimumValue,
                    _wheelStiffnessMaximumValue = BugeeWheelStiffnessMaximumValue,
                    _wheelStiffnessMinimumValue = BugeeWheelStiffnessMinimumValue,
                    _abilityPowerMaximumValue = 0,
                    _abilityPowerMinimumValue = 0,
                    _abilityTimeMaximumValue = 0,
                    _abilityTimeMinimumValue = 0,
                };
            case Vehicles.Military6X6:
                return new PartUpgrade
                {
                    _ammoMaximumValue = MilitaryAmmoMaximumValue,
                    _ammoMinimumValue = MilitaryAmmoMinimumValue,
                    _brakeMaximumValue = MilitaryBrakeMaximumValue,
                    _brakeMinimumValue = MilitaryBrakeMinimumValue,
                    _durabilityMaximumValue = MilitaryDurabilityMaximumValue,
                    _durabilityMinimumValue = MilitaryDurabilityMinimumValue,
                    _engineMaximumValue = MilitaryMotorMaximumValue,
                    _engineMinimumValue = MilitaryMotorMinimumValue,
                    _fuelMaximumValue = MilitaryFuelMaximumValue,
                    _fuelMinimumValue = MilitaryFuelMinimumValue,
                    _healthMaximumValue = MilitaryHealthMaximumValue,
                    _healthMinimumValue = MilitaryHealthMinimumValue,
                    _massMaximumValue = MilitaryMassMaximumValue,
                    _massMinimumValue = MilitaryMassMinimumValue,
                    _boostFuelMaximumValue = MilitaryBoostFuelMaximumValue,
                    _boostFuelMinimumValue = MilitaryBoostFuelMinimumValue,
                    _fuelConsumptionIdleMinimumValue = MilitaryIdleFuelConsumptionMinimumValue,
                    _fuelConsumptionIdleMaximumValue = MilitaryIdleFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMaximumValue = MilitaryGasFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMinimumValue = MilitaryGasFuelConsumptionMinimumValue,
                    _boostPowerMaximumValue = MilitaryBoostPowerMaximumValue,
                    _boostPowerMinimumValue = MilitaryBoostPowerMinimumValue,
                    _boostRegenMaximumValue = MilitaryBoostRegenMaximumValue,
                    _boostRegenMinimumValue = MilitaryBoostRegenMinimumValue,
                    _wheelStiffnessMaximumValue = MilitaryWheelStiffnessMaximumValue,
                    _wheelStiffnessMinimumValue = MilitaryWheelStiffnessMinimumValue,
                    _abilityPowerMaximumValue = 0,
                    _abilityPowerMinimumValue = 0,
                    _abilityTimeMaximumValue = 0,
                    _abilityTimeMinimumValue = 0,
                };
            case Vehicles.Fustang:
                return new PartUpgrade
                {
                    _ammoMaximumValue = FustangAmmoMaximumValue,
                    _ammoMinimumValue = FustangAmmoMinimumValue,
                    _brakeMaximumValue = FustangBrakeMaximumValue,
                    _brakeMinimumValue = FustangBrakeMinimumValue,
                    _durabilityMaximumValue = FustangDurabilityMaximumValue,
                    _durabilityMinimumValue = FustangDurabilityMinimumValue,
                    _engineMaximumValue = FustangMotorMaximumValue,
                    _engineMinimumValue = FustangMotorMinimumValue,
                    _fuelMaximumValue = FustangFuelMaximumValue,
                    _fuelMinimumValue = FustangFuelMinimumValue,
                    _healthMaximumValue = FustangHealthMaximumValue,
                    _healthMinimumValue = FustangHealthMinimumValue,
                    _massMaximumValue = FustangMassMaximumValue,
                    _massMinimumValue = FustangMassMinimumValue,
                    _boostFuelMaximumValue = FustangBoostFuelMaximumValue,
                    _boostFuelMinimumValue = FustangBoostFuelMinimumValue,
                    _fuelConsumptionIdleMinimumValue = FustangIdleFuelConsumptionMinimumValue,
                    _fuelConsumptionIdleMaximumValue = FustangIdleFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMaximumValue = FustangGasFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMinimumValue = FustangGasFuelConsumptionMinimumValue,
                    _boostPowerMaximumValue = FustangBoostPowerMaximumValue,
                    _boostPowerMinimumValue = FustangBoostPowerMinimumValue,
                    _boostRegenMaximumValue = FustangBoostRegenMaximumValue,
                    _boostRegenMinimumValue = FustangBoostRegenMinimumValue,
                    _wheelStiffnessMaximumValue = FustangWheelStiffnessMaximumValue,
                    _wheelStiffnessMinimumValue = FustangWheelStiffnessMinimumValue,
                    _abilityPowerMaximumValue = FustangAbilityPowerMaximumValue,
                    _abilityPowerMinimumValue = FustangAbilityPowerMinimumValue,
                    _abilityTimeMaximumValue = FustangAbilityTimeMaximumValue,
                    _abilityTimeMinimumValue = FustangAbilityTimeMinimumValue,
                };
            case Vehicles.KnightRider:
                return new PartUpgrade
                {
                    _ammoMaximumValue = KnightRiderAmmoMaximumValue,
                    _ammoMinimumValue = KnightRiderAmmoMinimumValue,
                    _brakeMaximumValue = KnightRiderBrakeMaximumValue,
                    _brakeMinimumValue = KnightRiderBrakeMinimumValue,
                    _durabilityMaximumValue = KnightRiderDurabilityMaximumValue,
                    _durabilityMinimumValue = KnightRiderDurabilityMinimumValue,
                    _engineMaximumValue = KnightRiderMotorMaximumValue,
                    _engineMinimumValue = KnightRiderMotorMinimumValue,
                    _fuelMaximumValue = KnightRiderFuelMaximumValue,
                    _fuelMinimumValue = KnightRiderFuelMinimumValue,
                    _healthMaximumValue = KnightRiderHealthMaximumValue,
                    _healthMinimumValue = KnightRiderHealthMinimumValue,
                    _massMaximumValue = KnightRiderMassMaximumValue,
                    _massMinimumValue = KnightRiderMassMinimumValue,
                    _boostFuelMaximumValue = KnightRiderBoostFuelMaximumValue,
                    _boostFuelMinimumValue = KnightRiderBoostFuelMinimumValue,
                    _fuelConsumptionIdleMinimumValue = KnightRiderIdleFuelConsumptionMinimumValue,
                    _fuelConsumptionIdleMaximumValue = KnightRiderIdleFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMaximumValue = KnightRiderGasFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMinimumValue = KnightRiderGasFuelConsumptionMinimumValue,
                    _boostPowerMaximumValue = KnightRiderBoostPowerMaximumValue,
                    _boostPowerMinimumValue = KnightRiderBoostPowerMinimumValue,
                    _boostRegenMaximumValue = KnightRiderBoostRegenMaximumValue,
                    _boostRegenMinimumValue = KnightRiderBoostRegenMinimumValue,
                    _wheelStiffnessMaximumValue = KnightRiderWheelStiffnessMaximumValue,
                    _wheelStiffnessMinimumValue = KnightRiderWheelStiffnessMinimumValue,
                    _abilityPowerMaximumValue = KnightRiderAbilityPowerMaximumValue,
                    _abilityPowerMinimumValue = KnightRiderAbilityPowerMinimumValue,
                    _abilityTimeMaximumValue = KnightRiderAbilityTimeMaximumValue,
                    _abilityTimeMinimumValue = KnightRiderAbilityTimeMinimumValue,
                };
            default:
                return new PartUpgrade
                {
                    _ammoMaximumValue = HatchbackAmmoMaximumValue,
                    _ammoMinimumValue = HatchbackAmmoMinimumValue,
                    _brakeMaximumValue = HatchbackBrakeMaximumValue,
                    _brakeMinimumValue = HatchbackBrakeMinimumValue,
                    _durabilityMaximumValue = HatchbackDurabilityMaximumValue,
                    _durabilityMinimumValue = HatchbackDurabilityMinimumValue,
                    _engineMaximumValue = HatchbackMotorMaximumValue,
                    _engineMinimumValue = HatchbackMotorMinimumValue,
                    _fuelMaximumValue = HatchbackFuelMaximumValue,
                    _fuelMinimumValue = HatchbackFuelMinimumValue,
                    _healthMaximumValue = HatchbackHealthMaximumValue,
                    _healthMinimumValue = HatchbackHealthMinimumValue,
                    _massMaximumValue = HatchbackMassMaximumValue,
                    _massMinimumValue = HatchbackMassMinimumValue,
                    _boostFuelMaximumValue = HatchbackBoostFuelMaximumValue,
                    _boostFuelMinimumValue = HatchbackBoostFuelMinimumValue,
                    _fuelConsumptionIdleMinimumValue = HatchbackIdleFuelConsumptionMinimumValue,
                    _fuelConsumptionIdleMaximumValue = HatchbackIdleFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMaximumValue = HatchbackGasFuelConsumptionMaximumValue,
                    _fuelConsumptionGasMinimumValue = HatchbackGasFuelConsumptionMinimumValue,
                    _boostPowerMaximumValue = HatchbackBoostPowerMaximumValue,
                    _boostPowerMinimumValue = HatchbackBoostPowerMinimumValue,
                    _boostRegenMaximumValue = HatchbackBoostRegenMaximumValue,
                    _boostRegenMinimumValue = HatchbackBoostRegenMinimumValue,
                    _wheelStiffnessMaximumValue = HatchbackWheelStiffnessMaximumValue,
                    _wheelStiffnessMinimumValue = HatchbackWheelStiffnessMinimumValue,
                    _abilityPowerMaximumValue = 0,
                    _abilityPowerMinimumValue = 0,
                    _abilityTimeMaximumValue = 0,
                    _abilityTimeMinimumValue = 0,
                };
        }
    }
}