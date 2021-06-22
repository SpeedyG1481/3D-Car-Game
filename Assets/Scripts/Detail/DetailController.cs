using UnityEngine;

public class DetailController : MonoBehaviour
{
    private void Start()
    {
        var detailType = GameController.GetCurrentDetailLevel();
        if (detailType != DetailType.High)
        {
            var i = 0;
            foreach (Transform child in transform)
            {
                var active = i % (detailType == DetailType.Low ? 4 : 2) == 0;
                child.gameObject.SetActive(active);
                i++;
            }
        }
    }
}