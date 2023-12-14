using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    public float attackRange;
    public float attackDamage;
    public float attackCooldown;
    public bool canAttack;
    public PlayerHealth player;
    public Rigidbody2D rbody;
    public void CheckAttack()
    {
        if (Vector2.Distance(transform.position, player.gameObject.transform.position) < attackRange && canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackAction());
        }
    }

    public abstract IEnumerator AttackAction();
}
