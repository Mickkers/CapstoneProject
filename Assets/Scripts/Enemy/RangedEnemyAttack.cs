using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : EnemyAttack
{
    [SerializeField] private RangedProjectile projectilePrefab;

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

        RangedProjectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.damage = attackDamage;
        
        projectile.direction = Vector3.Normalize(player.transform.position - transform.position);

        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        canAttack = true;
    }
}
