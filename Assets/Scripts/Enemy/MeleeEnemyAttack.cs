using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : EnemyAttack
{

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

    public override IEnumerator AttackAction()
    {
        rbody.constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(attackCooldown);

        if (Vector2.Distance(transform.position, player.gameObject.transform.position) <= attackRange)
        {
            player.TakeDamage(attackDamage);
        }
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        canAttack = true;
    }
}
