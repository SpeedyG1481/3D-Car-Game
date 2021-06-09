using UnityEngine;
using UnityEngine.UI;

public class EndLevelAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] levelSprites;
    private Image _image;
    private static float AnimationTime = 10F;
    private float _timer;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.sprite = levelSprites[GameController.CurrentPlayingLevel - 1];
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > AnimationTime)
        {
            _timer = -1;
            GameController.CurrentPlayingLevel++;
            if (GameController.CurrentPlayingLevel >= 4)
                SceneLoader.Load(Scenes.About);
            else
                SceneLoader.Load(Scenes.Garage);
        }
    }
}