using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private GameObject fpsCounter;
    
    void Update()
    {
        fpsCounter.SetActive(PlayerPrefs.GetInt("FpsCounter") != 0);
    }
}