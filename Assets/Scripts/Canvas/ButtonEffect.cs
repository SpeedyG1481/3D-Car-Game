using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonEffect : MonoBehaviour
{
    [SerializeField] [Range(0.1F, 1.0F)] private float alpha = 0.75F;
    private Image _image;

    public virtual void Start()
    {
        _image = GetComponent<Image>();
    }

    public void Press()
    {
        var color = _image.color;
        color.a = alpha;
        _image.color = color;
    }

    public void Up()
    {
        var color = _image.color;
        color.a = 1.0F;
        _image.color = color;
    }
}