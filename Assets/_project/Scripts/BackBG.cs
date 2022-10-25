using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBG : MonoBehaviour
{
    [Min(0)]
    [SerializeField] float _speed;

    private Rigidbody2D _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _body.velocity = new Vector2(-_speed * Time.deltaTime, 0); 
        //transform.position -= new Vector3(_speed * Time.deltaTime, 0);
    }
}
