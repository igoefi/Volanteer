using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static UnityEvent Tap = new();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Tap.Invoke();
    }
}
