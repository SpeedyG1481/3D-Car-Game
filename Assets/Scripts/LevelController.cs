using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Range(1, 4)] [SerializeField] private int level;

    void Start()
    {
        GameController.CurrentPlayingLevel = level;
    }
}