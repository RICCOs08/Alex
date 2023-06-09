using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _lifes;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();

        if(Input.GetButtonDown("Vertical") && IsGrounded())
            Jump();

        if (IsGrounded()) State = States.idle;
    }

    private void Run()
    {
        if (IsGrounded()) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);
        _spriteRenderer.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private States State
    {
        get { return (States)_anim.GetInteger("State"); }
        set { _anim.SetInteger("State", (int)value); }
    }
}

public enum States
{
    idle,
    run
}
