using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform _stick;
    private RectTransform _rectTransform;

    [SerializeField, Range(0, 150)]
    private float _stickRange;

    private Vector2 _direction;
    private bool _isInput;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlStick(eventData);
        _isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlStick(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _stick.anchoredPosition = Vector2.zero;
        _direction = Vector2.zero;
        _isInput = false;
    }

    private void ControlStick(PointerEventData eventData)
    {
        var inputPos = eventData.position - _rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < _stickRange ? inputPos : inputPos.normalized * _stickRange;
        _stick.anchoredPosition = inputVector;
        _direction = inputVector / _stickRange;
    }

    public bool ActiveJoyStick()
    {
        return _isInput;
    }
    
    public Vector2 StickDirection()
    {
        return _direction;
    }
}
