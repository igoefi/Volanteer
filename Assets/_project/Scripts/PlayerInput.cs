using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static UnityEvent TapEvent { get; private set; } = new();
    public static UnityEvent LeftSwipeEvent { get; private set; } = new();
    public static UnityEvent DownSwipeEvent { get; private set; } = new();

    private Vector2 _firstTouchVector;
    private Vector2 _lastTouchVector;

    [SerializeField] float lengthXSwipe;
    [SerializeField] float lengthYSwipe;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstTouchVector = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lastTouchVector = Input.mousePosition;
            CheckSwipe();
        }
    }

    private void CheckSwipe()
    {
        float xDistance = _firstTouchVector.x - _lastTouchVector.x;
        float yDistance = _firstTouchVector.y - _lastTouchVector.y;

        if (xDistance < lengthXSwipe && yDistance < lengthYSwipe) 
        {
            Debug.Log("1");
            TapEvent.Invoke(); 
            return; 
        }
        Debug.Log('2');

        UnityEvent xEvent = null;
        UnityEvent yEvent = null;
        UnityEvent needEvent;

        if (xDistance >= lengthXSwipe)
            xEvent = LeftSwipeEvent;
        if (yDistance >= lengthYSwipe)
            yEvent = DownSwipeEvent;


        if (xEvent != null && yEvent != null)
        {
            needEvent = Math.Abs(xDistance) > Math.Abs(yDistance) ? xEvent : yEvent;
        }

        needEvent = xEvent != null ? xEvent : yEvent;

        needEvent.Invoke();
    }
}
