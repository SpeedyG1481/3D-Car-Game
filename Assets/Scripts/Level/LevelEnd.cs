using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject endScreenCanvas;
    private bool _onlyOne = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle") && !_onlyOne)
        {
            GameController.GoNextLevel();
            endScreenCanvas.SetActive(true);
            _onlyOne = true;
        }
    }
}