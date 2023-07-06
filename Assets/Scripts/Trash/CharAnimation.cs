using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    private Animator _animator;
    public bool IsMoving { private get; set; }
    public bool IsFlying { private get; set; }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        _animator.SetBool("IsMoving", IsMoving);
        _animator.SetBool("IsFlying", IsFlying);
    }

    public void Jump()
    {
        _animator.SetTrigger("Jump");
    }
}
