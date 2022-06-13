using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform _stick;
    private RectTransform _rectTransform;
    //[SerializeField, Range(0, 150)]
    //private float _stickRange;

    //private Vector2 _direction;
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
        Debug.Log(_rectTransform.anchoredPosition);
        Debug.Log(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlStick(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _stick.anchoredPosition = Vector2.zero;
        //_direction = Vector2.zero;
        _isInput = false;
    }

    private void ControlStick(PointerEventData eventData)
    {
        //var inputPos = _rectTransform.anchoredPosition - eventData.position;
        //var inputVector = inputPos.magnitude < _stickRange ? inputPos : inputPos.normalized * _stickRange;
        //_stick.anchoredPosition = inputVector;
        //_direction = inputVector / _stickRange;

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
