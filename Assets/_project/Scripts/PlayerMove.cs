using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _body;

    [SerializeField] float _speed;
    [SerializeField] float _maxSpeed;

    [SerializeField] float _jumpForce;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();

        PlayerInput.TapEvent.AddListener(Jump);
    }

    void Update()
    {
        _body.velocity += new Vector2(_speed * Time.deltaTime, 0);
        if (_body.velocity.x > _maxSpeed)
            _body.velocity = new Vector2(_maxSpeed, _body.velocity.y);
    }

    private void Jump()
    {
        _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
