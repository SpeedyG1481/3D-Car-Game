using UnityEngine;
using UnityEngine.UI;

public class NeedsPanelClose : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        panel.SetActive(false);
    }
}