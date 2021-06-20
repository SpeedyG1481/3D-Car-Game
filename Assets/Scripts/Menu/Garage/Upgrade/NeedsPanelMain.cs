using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NeedsPanelMain : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private UpgradeType upgradeType;

    [SerializeField] private TextMeshProUGUI steelNeedText;
    [SerializeField] private TextMeshProUGUI motorNeedText;
    [SerializeField] private TextMeshProUGUI brakeNeedText;
    [SerializeField] private TextMeshProUGUI turboNeedText;
    [SerializeField] private TextMeshProUGUI capsuleNeedText;
    [SerializeField] private TextMeshProUGUI suspensionNeedText;
    [SerializeField] private TextMeshProUGUI ammoNeedText;
    [SerializeField] private TextMeshProUGUI gasolineNeedText;

    [SerializeField] private TextMeshProUGUI steelCountText;
    [SerializeField] private TextMeshProUGUI motorCountText;
    [SerializeField] private TextMeshProUGUI brakeCountText;
    [SerializeField] private TextMeshProUGUI turboCountText;
    [SerializeField] private TextMeshProUGUI capsuleCountText;
    [SerializeField] private TextMeshProUGUI suspensionCountText;
    [SerializeField] private TextMeshProUGUI ammoCountText;
    [SerializeField] private TextMeshProUGUI gasolineCountText;

    [SerializeField] private TextMeshProUGUI steelPowerText;
    [SerializeField] private TextMeshProUGUI motorPowerText;
    [SerializeField] private TextMeshProUGUI brakePowerText;
    [SerializeField] private TextMeshProUGUI turboPowerText;
    [SerializeField] private TextMeshProUGUI capsulePowerText;
    [SerializeField] private TextMeshProUGUI suspensionPowerText;
    [SerializeField] private TextMeshProUGUI ammoPowerText;
    [SerializeField] private TextMeshProUGUI gasolinePowerText;

    [SerializeField] private UpgradePartButton upgradePartButton;

    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        panel.SetActive(true);
        upgradePartButton.upgradeType = upgradeType;
    }

    private void LateUpdate()
    {
        if (panel.activeInHierarchy)
            DataUpgrade();
    }

    private void DataUpgrade()
    {
        var upgrade = Upgrade.GetUpgradeData(upgradeType);
        var partUpgradeData = PartUpgrade.GetPartUpgrade();

        steelNeedText.text = upgrade.SteelNeed + "x";
        steelNeedText.color = GameController.SteelCount >= upgrade.SteelNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);
        steelPowerText.text = "+%" + (partUpgradeData.Durability /
                (partUpgradeData.DurabilityMaximumValue + partUpgradeData.DurabilityMinimumValue) * 100)
            .ToString("0.00");
        steelCountText.text = GameController.SteelCount.ToString();

        motorNeedText.text = upgrade.MotorNeed + "x";
        motorNeedText.color = GameController.MotorCount >= upgrade.MotorNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);
        motorPowerText.text = "+%" + (partUpgradeData.Engine /
                (partUpgradeData.EngineMaximumValue + partUpgradeData.EngineMinimumValue) * 100)
            .ToString("0.00");
        motorCountText.text = GameController.MotorCount.ToString();

        brakeNeedText.text = upgrade.BrakeNeed + "x";
        brakeNeedText.color = GameController.BrakeCount >= upgrade.BrakeNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);
        brakePowerText.text = "+%" + (partUpgradeData.Brake /
                (partUpgradeData.BrakeMaximumValue + partUpgradeData.BrakeMinimumValue) * 100)
            .ToString("0.00");
        brakeCountText.text = GameController.BrakeCount.ToString();

        turboNeedText.text = upgrade.TurboNeed + "x";
        turboNeedText.color = GameController.TurboCount >= upgrade.TurboNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);
        turboPowerText.text = "+%" + (partUpgradeData.BoostPower /
                (partUpgradeData.BoostPowerMaximumValue + partUpgradeData.BoostPowerMinimumValue) * 100)
            .ToString("0.00");
        turboCountText.text = GameController.TurboCount.ToString();

        capsuleNeedText.text = upgrade.CapsuleNeed + "x";
        capsuleNeedText.color =
            GameController.CapsuleCount >= upgrade.CapsuleNeed
                ? new Color32(51, 173, 0, 255)
                : new Color32(255, 64, 0, 255);
        capsulePowerText.text = "+%" + (partUpgradeData.Health /
                (partUpgradeData.HealthMaximumValue + partUpgradeData.HealthMinimumValue) * 100)
            .ToString("0.00");
        capsuleCountText.text = GameController.CapsuleCount.ToString();

        suspensionNeedText.text = upgrade.SuspensionNeed + "x";
        suspensionNeedText.color =
            GameController.SuspensionCount >= upgrade.SuspensionNeed
                ? new Color32(51, 173, 0, 255)
                : new Color32(255, 64, 0, 255);
        suspensionPowerText.text = "+%" + (partUpgradeData.WheelStiffness /
                (partUpgradeData.WheelStiffnessMaximumValue +
                 partUpgradeData.WheelStiffnessMinimumValue) * 100)
            .ToString("0.00");
        suspensionCountText.text = GameController.SuspensionCount.ToString();

        ammoNeedText.text = upgrade.AmmoNeed + "x";
        ammoNeedText.color = GameController.AmmoCount >= upgrade.AmmoNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);
        ammoPowerText.text = "+%" + (partUpgradeData.Ammo /
                (partUpgradeData.AmmoMaximumValue + partUpgradeData.AmmoMinimumValue) * 100)
            .ToString("0.00");
        ammoCountText.text = GameController.AmmoCount.ToString();

        gasolineNeedText.text = upgrade.GasolineNeed + "x";
        gasolineNeedText.color =
            GameController.GasolineCount >= upgrade.GasolineNeed
                ? new Color32(51, 173, 0, 255)
                : new Color32(255, 64, 0, 255);
        gasolinePowerText.text = "+%" + (partUpgradeData.Fuel /
                (partUpgradeData.FuelMaximumValue + partUpgradeData.FuelMinimumValue) * 100)
            .ToString("0.00");
        gasolineCountText.text = GameController.GasolineCount.ToString();
    }
}