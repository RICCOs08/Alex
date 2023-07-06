using UnityEngine;

public class _PlayerController_ : MonoBehaviour
{
    [SerializeField] private int _lives = 3;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 8f;

    private bool _isGrounded;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();

        if(_isGrounded && Input.GetButtonDown("Vertical"))
            Jump();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Run()
    {
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
    }
}
