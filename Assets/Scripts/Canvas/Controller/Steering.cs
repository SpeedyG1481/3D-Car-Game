using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Steering : MonoBehaviour
{
    public Graphic uiElement;

    private RectTransform _rectT;
    private Vector2 _centerPoint;

    public float maximumSteeringAngle = 200f;
    public float wheelReleasedSpeed = 200f;

    private float _wheelAngle = 0f;
    private float _wheelPrevAngle = 0f;

    private bool _wheelBeingHeld = false;

    public float GetClampedValue()
    {
        return _wheelAngle / maximumSteeringAngle;
    }

    public float GetAngle()
    {
        return _wheelAngle;
    }

    void Start()
    {
        _rectT = uiElement.rectTransform;
        InitEventsSystem();
    }

    void Update()
    {
        if (!_wheelBeingHeld && !Mathf.Approximately(0f, _wheelAngle))
        {
            var deltaAngle = wheelReleasedSpeed * Time.deltaTime;
            if (Mathf.Abs(deltaAngle) > Mathf.Abs(_wheelAngle))
                _wheelAngle = 0f;
            else if (_wheelAngle > 0f)
                _wheelAngle -= deltaAngle;
            else
                _wheelAngle += deltaAngle;
        }

        // Rotate the wheel image
        _rectT.localEulerAngles = Vector3.back * _wheelAngle;
        Vehicle.HorizontalInput = GetClampedValue();
        //Debug.Log("Steering Value: " + GetClampedValue());
    }

    void InitEventsSystem()
    {
        // Warning: Be ready to see some extremely boring code here :-/
        // You are warned!
        EventTrigger events = uiElement.gameObject.GetComponent<EventTrigger>();

        if (events == null)
            events = uiElement.gameObject.AddComponent<EventTrigger>();

        if (events.triggers == null)
            events.triggers = new List<EventTrigger.Entry>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.TriggerEvent callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> functionCall = new UnityAction<BaseEventData>(PressEvent);
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback = callback;

        events.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>(DragEvent);
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.Drag;
        entry.callback = callback;

        events.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>(ReleaseEvent); //
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback = callback;

        events.triggers.Add(entry);
    }

    public void PressEvent(BaseEventData eventData)
    {
        // Executed when mouse/finger starts touching the steering wheel
        Vector2 pointerPos = ((PointerEventData) eventData).position;

        _wheelBeingHeld = true;
        _centerPoint =
            RectTransformUtility.WorldToScreenPoint(((PointerEventData) eventData).pressEventCamera, _rectT.position);
        _wheelPrevAngle = Vector2.Angle(Vector2.up, pointerPos - _centerPoint);
    }

    public void DragEvent(BaseEventData eventData)
    {
        // Executed when mouse/finger is dragged over the steering wheel
        Vector2 pointerPos = ((PointerEventData) eventData).position;

        float wheelNewAngle = Vector2.Angle(Vector2.up, pointerPos - _centerPoint);
        // Do nothing if the pointer is too close to the center of the wheel
        if (Vector2.Distance(pointerPos, _centerPoint) > 20f)
        {
            if (pointerPos.x > _centerPoint.x)
                _wheelAngle += wheelNewAngle - _wheelPrevAngle;
            else
                _wheelAngle -= wheelNewAngle - _wheelPrevAngle;
        }

        // Make sure wheel angle never exceeds maximumSteeringAngle
        _wheelAngle = Mathf.Clamp(_wheelAngle, -maximumSteeringAngle, maximumSteeringAngle);
        _wheelPrevAngle = wheelNewAngle;
    }

    public void ReleaseEvent(BaseEventData eventData)
    {
        // Executed when mouse/finger stops touching the steering wheel
        // Performs one last DragEvent, just in case
        DragEvent(eventData);

        _wheelBeingHeld = false;
    }
}