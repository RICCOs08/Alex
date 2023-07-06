using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHalth = 100;
    private int _currentHealth;
    [SerializeField] private Animator _anim;
    void Start()
    {
        _currentHealth = _maxHalth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _anim.SetTrigger("Damage");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("He's dead.");

        _anim.SetBool("IsDead", true);

        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
