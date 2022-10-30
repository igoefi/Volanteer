using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _indentX;

    private float _zCoordinate;
    private float _yCoordinate;

    private Rigidbody2D _body;
    private void Start()
    {
        _zCoordinate = transform.position.z;
        _yCoordinate = transform.position.y;

        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        //transform.position = new Vector3(_player.position.x + _indentX, _yCoordinate, _zCoordinate);
    }

    private void FixedUpdate()
    {
        _body.MovePosition(new Vector2(_player.position.x + _indentX, _yCoordinate));
    }
}
