using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLaayer;

    [SerializeField] private int _attackDamage = 100;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Attack();
    }

    private void Attack()
    {
        _anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLaayer);

        foreach (Collider2D enemy in  hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

    
}
