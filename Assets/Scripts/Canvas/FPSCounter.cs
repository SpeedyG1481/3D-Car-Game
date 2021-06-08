using System;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    private float _timer = 0;

    void Start()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 0.5F)
        {
            _textMeshProUGUI.text = String.Format("{0:.#}", 1.0f / Time.deltaTime);
            _timer = 0;
        }
    }
}