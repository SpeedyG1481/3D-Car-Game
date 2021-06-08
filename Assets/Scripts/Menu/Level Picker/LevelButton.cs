using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject lockObject;
    [SerializeField] private AudioSource audioSource;
    private Button _button;


    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
        lockObject.SetActive(!GameController.CanPlay(level));
    }

    private void ButtonListener()
    {
        if (GameController.CanPlay(level))
        {
            GameController.CurrentPlayingLevel = level;
            SceneLoader.Load(Scenes.Garage);
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            audioSource.volume = GameController.GetSfxVolume;
            audioSource.PlayOneShot(clip, GameController.GetSfxVolume);
        }
    }
}