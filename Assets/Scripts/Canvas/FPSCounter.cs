using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    private float _timer = 0;

    private void Start()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 0.25F)
        {
            var fps = 1.0f / Time.unscaledDeltaTime;
            _textMeshProUGUI.text = Mathf.Ceil(fps).ToString();
            //_textMeshProUGUI.text = String.Format("{0:.#}", Time.frameCount);
            _timer = 0;
        }
    }
}