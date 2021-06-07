using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Loading : MonoBehaviour
{
    public Sprite[] sprites;
    private Image _image;
    private bool _isFirstUpdate = true;

    private void Start()
    {
        _image = GetComponent<Image>();
        if (sprites.Length > 0)
        {
            var random = (new Random()).Next(sprites.Length);
            _image.sprite = sprites[random];
        }
    }

    void Update()
    {
        if (_isFirstUpdate)
        {
            SceneLoader.LoaderCallback();
            _isFirstUpdate = false;
        }
    }
}