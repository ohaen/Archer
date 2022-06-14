using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform _stick;
    private RectTransform _rectTransform;
    private bool _isInput;
    private Vector3 _inputVector;

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
        _isInput = false;
    }

    private void ControlStick(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / _rectTransform.sizeDelta.x);
            pos.y = (pos.y / _rectTransform.sizeDelta.y);

            _inputVector = new Vector3(pos.x * 2 + 0, 0, pos.y * 2 - 0);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            _stick.anchoredPosition = new Vector3(_inputVector.x * (_rectTransform.sizeDelta.x / 2), _inputVector.z * (_rectTransform.sizeDelta.y / 2));
        }
    }

    public bool ActiveJoyStick()
    {
        return _isInput;
    }
    
    public Vector3 StickDirection()
    {
        return _inputVector;
    }
}
