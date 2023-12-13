using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : EnemyAttack
{
    private PlayerHealth player;
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
        rbody = GetComponent<Rigidbody2D>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        if(Vector2.Distance(transform.position, player.gameObject.transform.position) < attackRange && canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackAction());
        }
    }

    private IEnumerator AttackAction()
    {
        rbody.constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(attackCooldown);

        if(Vector2.Distance(transform.position, player.gameObject.transform.position) <= attackRange)
        {
            player.TakeDamage(attackDamage);
        }
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        canAttack = true;
    }
}
