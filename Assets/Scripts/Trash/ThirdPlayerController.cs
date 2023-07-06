using UnityEngine;

public class ThirdPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private SpriteRenderer _spriteChar;
    [SerializeField] private float _jumpForce = 4f;
    [SerializeField] private Vector3 _groundCheckOffset;
    private Vector3 _input;
    private Rigidbody2D _rigidbody;
    private CharAnimation _animations;
    private bool _isMoving;
    private bool _isGrounded;
    private bool _isFlying;

    public LayerMask groundMask;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<CharAnimation>();
    }


    private void FixedUpdate()
    {
        Move();
        CheckGround();
        if (Input.GetButton("Jump"))
        {

            if (_isGrounded)
            {
                Jump();
                _animations.Jump();
            }
        }

        _animations.IsMoving = _isMoving;
        _animations.IsFlying = IsFlying();
    }

    private void Move()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;

        if (_isMoving)
        {
            _spriteChar.flipX = _input.x > 0 ? false : true;
        }

        _animations.IsMoving = _isMoving;
    }

    private void Jump()
    {
        Debug.Log("Jump");
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        float rayLenth = 0.3f;
        Vector3 rayStartPosition = transform.position + _groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, rayStartPosition + Vector3.down, rayLenth, groundMask);

        if (hit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private bool IsFlying()
    {
        if (_rigidbody.velocity.y < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
