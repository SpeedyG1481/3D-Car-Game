using UnityEngine;

public class About : MonoBehaviour
{
    [SerializeField] private int time = 35;

    private float _timer = 0;

    void Update()
    {
        _timer += Time.deltaTime;
        if (Input.anyKey || _timer > time)
        {
            SceneLoader.Load(Scenes.Menu);
        }
    }
}