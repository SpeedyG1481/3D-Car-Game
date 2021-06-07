using UnityEngine;

public class About : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneLoader.Load(Scenes.Menu);
        }
    }
}