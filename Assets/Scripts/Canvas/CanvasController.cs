using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject[] button;
    [SerializeField] private GameObject[] wheel;

    [SerializeField] private GameObject[] rotationButtons;

    private SteeringTypes _steering;

    private void Start()
    {
        _steering = GameController.GetCurrentSteeringType();
        foreach (var buttons in button)
        {
            buttons.SetActive(_steering == SteeringTypes.Button);
        }

        foreach (var wheels in wheel)
        {
            wheels.SetActive(_steering == SteeringTypes.Wheel);
        }

        var i = 0;
        if (_steering == SteeringTypes.Tilt)
        {
            foreach (var rotationButton in rotationButtons)
            {
                var vector = new Vector2(170, 170);
                if (i == 1)
                {
                    vector = new Vector2(375, 170);
                }

                var rectTransform = rotationButton.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = vector;
                i++;
            }
        }
    }
}