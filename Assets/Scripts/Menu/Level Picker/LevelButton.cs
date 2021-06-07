using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Scenes level;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        switch (level)
        {
            case Scenes.Level1:
                GameController.CurrentPlayingLevel = 1;
                break;
            case Scenes.Level2:
                GameController.CurrentPlayingLevel = 2;
                break;
            case Scenes.Level3:
                GameController.CurrentPlayingLevel = 3;
                break;
            case Scenes.Level4:
                GameController.CurrentPlayingLevel = 4;
                break;
        }

        SceneLoader.Load(level);
    }
}