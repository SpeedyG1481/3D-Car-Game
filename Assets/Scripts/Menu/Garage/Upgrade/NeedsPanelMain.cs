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

    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        panel.SetActive(true);

        var upgrade = Upgrade.GetUpgradeData(upgradeType);
        steelNeedText.text = upgrade.SteelNeed + "x";
        steelNeedText.color = GameController.SteelCount >= upgrade.SteelNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);

        motorNeedText.text = upgrade.MotorNeed + "x";
        motorNeedText.color = GameController.MotorCount >= upgrade.MotorNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);

        brakeNeedText.text = upgrade.BrakeNeed + "x";
        brakeNeedText.color = GameController.BrakeCount >= upgrade.BrakeNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);

        turboNeedText.text = upgrade.TurboNeed + "x";
        turboNeedText.color = GameController.TurboCount >= upgrade.TurboNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);

        capsuleNeedText.text = upgrade.CapsuleNeed + "x";
        capsuleNeedText.color =
            GameController.CapsuleCount >= upgrade.CapsuleNeed
                ? new Color32(51, 173, 0, 255)
                : new Color32(255, 64, 0, 255);

        suspensionNeedText.text = upgrade.SuspensionNeed + "x";
        suspensionNeedText.color =
            GameController.SuspensionCount >= upgrade.SuspensionNeed
                ? new Color32(51, 173, 0, 255)
                : new Color32(255, 64, 0, 255);

        ammoNeedText.text = upgrade.AmmoNeed + "x";
        ammoNeedText.color = GameController.AmmoCount >= upgrade.AmmoNeed
            ? new Color32(51, 173, 0, 255)
            : new Color32(255, 64, 0, 255);

        gasolineNeedText.text = upgrade.GasolineNeed + "x";
        gasolineNeedText.color =
            GameController.GasolineCount >= upgrade.GasolineNeed
                ? new Color32(51, 173, 0, 255)
                : new Color32(255, 64, 0, 255);
    }
}