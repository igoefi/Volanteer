using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _body;
    private Collider2D _collider;

    [SerializeField] float _speed;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] int _wallUpLayer;

    private bool _isGrounded;
    private PlayerInput _input;

    private GameObject _lastFloor;
    void Start()
    {
        _isGrounded = true;

        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();

        _input = GetComponent<PlayerInput>();
        _input.TapEvent.AddListener(Jump);
        _input.DownSwipeEvent.AddListener(Fall);
    } 

    
    void FixedUpdate()
    {
        if (!GameStateController.IsPlaying)
        {
            _body.velocity = Vector2.zero;
            return;
        }

        _body.velocity += new Vector2(_speed, 0);
        if (_body.velocity.x > _maxSpeed)
            _body.velocity = new Vector2(_maxSpeed, _body.velocity.y);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _body.velocity = new Vector2(_body.velocity.x, 0);
            _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            return;
        }

    }

    private void Fall()
    {
        if (_lastFloor == null) return;
        if (_lastFloor.layer != _wallUpLayer) return;
        Debug.Log(true);
        _isGrounded = false;
        StartCoroutine(BeUnUse());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D hit = ReturnUnderHit();
        if (hit == null) return;
        if (hit.gameObject.tag != "Floor") return;

        _isGrounded = true;
        _lastFloor = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Floor") return;
        if (collision.gameObject != _lastFloor) return;

        _isGrounded = false;
        _lastFloor = null;
    }

    private Collider2D ReturnUnderHit()
    {
        Vector3 max = _collider.bounds.max;
        Vector3 min = _collider.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .1f);


        return Physics2D.OverlapArea(corner1, corner2);
    }
    private IEnumerator BeUnUse()
    {
        Collider2D floorCollider = _lastFloor.GetComponent<Collider2D>();

        floorCollider.isTrigger = true;

        yield return new WaitForSeconds(0.6f);

        floorCollider.isTrigger = false;
    }
}
