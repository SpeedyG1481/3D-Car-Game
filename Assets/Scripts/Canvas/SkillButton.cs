using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButton : ButtonEffect, IPointerDownHandler, IPointerUpHandler
{
    private Vehicle _vehicle;
    [SerializeField] private Image subImage;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Sprite jump;
    [SerializeField] private Sprite heal;

    private Sprite _showSprite;

    private bool _canShow;

    public override void Start()
    {
        base.Start();
        var vehicles = FindObjectsOfType<Vehicle>();
        foreach (var v in vehicles)
        {
            if (v.isActiveAndEnabled)
            {
                _vehicle = v;
                break;
            }
        }

        _canShow = subImage != null && _vehicle != null && jump != null && heal != null;
        SelectSprite();
    }

    private void SelectSprite()
    {
        if (_vehicle != null)
            switch (_vehicle.VehicleType)
            {
                case VehicleType.KnightRider:
                    _showSprite = jump;
                    break;
                case VehicleType.OldSedanVip:
                    _showSprite = heal;
                    break;
                default:
                    _canShow = false;
                    break;
            }
    }

    void Update()
    {
        if (_canShow)
        {
            if (_vehicle.CanUseSkill)
            {
                subImage.gameObject.SetActive(true);
                subImage.sprite = _showSprite;
                text.gameObject.SetActive(false);
            }
            else
            {
                var value = ((int) Math.Round(_vehicle.SkillTimer));
                if (value < 0)
                {
                    value = 0;
                }

                var t = value.ToString();
                subImage.gameObject.SetActive(false);
                text.gameObject.SetActive(true);
                text.text = t;
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _vehicle.UseSkill();
        Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Up();
    }
}