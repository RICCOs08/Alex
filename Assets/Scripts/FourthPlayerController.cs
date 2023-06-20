using UnityEngine;

public class FourthPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private Animator _anim;
    private bool Grounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.W) && Grounded)
            Jump();

        if(Input.GetKey(KeyCode.W))
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);

        _anim.SetBool("Run", horizontalInput != 0);
        _anim.SetBool("Grounded", Grounded);
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _speed);
        _anim.SetTrigger("Jump");
        Grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            Grounded = true;
    }
}
