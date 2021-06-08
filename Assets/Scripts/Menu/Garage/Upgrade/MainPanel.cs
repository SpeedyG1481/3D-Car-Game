using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private GameObject[] gameObjects;

    void Update()
    {
        var activeColumns = GameController.GetCurrentUpgradeLevel(upgradeType);
        for (var i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(i < activeColumns);
        }
    }
}