using UnityEngine;

public class EndLevelAnimation : MonoBehaviour
{
    private static float AnimationTime = 12.5F;
    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > AnimationTime)
        {
            GameController.CurrentPlayingLevel++;
            SceneLoader.Load(Scenes.Garage);
        }
    }
}