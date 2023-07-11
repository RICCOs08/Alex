using UnityEngine;

public class _PlayerController_ : MonoBehaviour
{
    [SerializeField] private int _lives = 3;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 8f;

    private bool _isGrounded;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;

    
    private States State
    {
        get { return (States)_anim.GetInteger("State");  }
        set { _anim.SetInteger("State", (int)value);  }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isGrounded)
            State = States.AlexIdle;

        if (Input.GetButton("Horizontal"))
            Run();

        if(_isGrounded && Input.GetKeyDown(KeyCode.W))
            Jump();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Run()
    {
        if (_isGrounded)
            State = States.AlexRun;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);

        _spriteRenderer.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);

        
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.8f);
        _isGrounded = collider.Length > 1;

        if (!_isGrounded)
            State = States.AlexJump;
    }

    public enum States
    {
        AlexIdle,
        AlexRun,
        AlexJump
    }
}
