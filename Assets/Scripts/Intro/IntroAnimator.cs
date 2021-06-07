using UnityEngine;

namespace Intro
{
    public class IntroAnimator : MonoBehaviour
    {
        private float _timer;
        private const float IntroTime = 6.25F;

        private void Awake()
        {
            Time.timeScale = 1F;
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
}