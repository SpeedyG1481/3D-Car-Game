using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoader
{
    public static class SceneLoader
    {
        public class LoadingMono : MonoBehaviour
        {
        }

        private static AsyncOperation _asyncOperation;
        private static Action _onLoaderCallback;

        public static float GetProgress => _asyncOperation?.progress ?? 0.01F;

        public static void Load(Scenes scene)
        {
            _onLoaderCallback = () =>
            {
                var gameObject = new GameObject("Loader");
                gameObject.AddComponent<LoadingMono>().StartCoroutine(LoadScene(scene));
            };

            SceneManager.LoadScene(Scenes.Loader.ToString());
        }

        private static IEnumerator LoadScene(Scenes scene)
        {
            yield return null;

            _asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
            while (!_asyncOperation.isDone)
            {
                yield return null;
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static void LoaderCallback()
        {
            if (_onLoaderCallback == null) return;
            _onLoaderCallback();
            _onLoaderCallback = null;
        }
    }
}