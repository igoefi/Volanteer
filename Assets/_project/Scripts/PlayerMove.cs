using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _body;

    [SerializeField] float _speed;
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _body.velocity += new Vector2(_speed * Time.deltaTime, 0);
        }
    }
}
