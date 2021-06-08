using UnityEngine;
using UnityEngine.UI;

public class UpgradePartButton : MonoBehaviour
{
    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip wrongSound;
    [SerializeField] private AudioClip successSound;


    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        if (audioSource.isPlaying) audioSource.Stop();
        if (GameController.CanUpgradeCarLevel(upgradeType))
        {
            GameController.UpgradePartLevel(upgradeType);
            audioSource.volume = GameController.GetSfxVolume;
            audioSource.PlayOneShot(successSound, GameController.GetSfxVolume);
        }
        else
        {
            audioSource.volume = GameController.GetSfxVolume;
            audioSource.PlayOneShot(wrongSound, GameController.GetSfxVolume);
        }
    }
}