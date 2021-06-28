using UnityEngine;

public class IntroAnimator : MonoBehaviour
{
    private float _timer;

    private const float IntroTime = 6.25F;

    private void Awake()
    {
        Time.timeScale = 1F;
    }

    private void Start()
    {
        Application.targetFrameRate = GameController.TargetFPS;
    }


    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= IntroTime)
        {
            SceneLoader.Load(Scenes.Menu);
        }
    }
}