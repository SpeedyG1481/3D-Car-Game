using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private Image fillImage;

    private void Update()
    {
        float activeColumns = GameController.GetCurrentUpgradeLevel(upgradeType);
        fillImage.fillAmount = activeColumns / GameController.TotalUpgrade;
    }
}