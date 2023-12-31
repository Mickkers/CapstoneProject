using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour
{
    private Rigidbody2D rbody;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;

    public float damage;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckLife();
    }

    private void CheckLife()
    {
        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
            
        lifeTime -= Time.fixedDeltaTime;
    }

    private void Move()
    {
        transform.Translate(direction.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
