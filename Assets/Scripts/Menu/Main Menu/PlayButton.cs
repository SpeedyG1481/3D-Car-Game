using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        SceneLoader.Load(Scenes.LevelPicker);
    }
}