using UnityEngine;
using UnityEngine.UI;

public class PlayGameButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        var level = Scenes.Level1;
        switch (GameController.CurrentPlayingLevel)
        {
            case 2:
                level = Scenes.Level2;
                break;
            case 3:
                level = Scenes.Level3;
                break;
            case 4:
                level = Scenes.Level4;
                break;
        }

        if (GameController.CanUseCar())
            SceneLoader.Load(level);
    }
}