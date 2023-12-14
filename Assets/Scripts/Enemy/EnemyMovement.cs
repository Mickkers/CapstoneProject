using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerHealth player;
    private EnemyHealth health;
    private Rigidbody2D rbody;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float chaseRange;


    private float attackRange;
    private Vector2 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        player = FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
        attackRange = GetComponent<EnemyAttack>().attackRange;
        rbody = GetComponent<Rigidbody2D>();
        health = GetComponent<EnemyHealth>();

    }


    void FixedUpdate()
    {
        if (health.isAlive)
        {
            CheckMove();
        }
    }

    private void CheckMove()
    {
        if(Vector2.Distance(transform.position, originalPosition) < 10f && Vector2.Distance(transform.position, player.gameObject.transform.position) <= chaseRange && Vector2.Distance(transform.position, player.gameObject.transform.position) >= attackRange)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 direction = player.gameObject.transform.position - transform.position;
        rbody.MovePosition(transform.position + direction.normalized * moveSpeed);
    }
}
