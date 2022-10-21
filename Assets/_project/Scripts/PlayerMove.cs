using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _body;

    [SerializeField] float _speed;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _jumpForce;

    private bool _isGrounded;
    private PlayerInput _input;
    void Start()
    {
        _isGrounded = true;

        _body = GetComponent<Rigidbody2D>();

        _input = GetComponent<PlayerInput>();
        _input.TapEvent.AddListener(Jump);
        _input.DownSwipeEvent.AddListener(Fall);
    } 

    
    void Update()
    {
        _body.velocity += new Vector2(_speed * Time.deltaTime, 0);
        if (_body.velocity.x > _maxSpeed)
            _body.velocity = new Vector2(_maxSpeed, _body.velocity.y);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void Fall()
    {
        _isGrounded = false;
        StartCoroutine(BeUnUse());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            _isGrounded = true;
        }
    }
    private IEnumerator BeUnUse()
    {
        GetComponent<Collider2D>().isTrigger = true;

        yield return new WaitForSeconds(0.22f);

        GetComponent<Collider2D>().isTrigger = false;
    }
}
