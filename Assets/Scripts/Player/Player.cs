using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 moveDirection;
    private Rigidbody2D rbody;
    private int currDirection;
    private EnumTools currTool;

    private bool canAttack = true;
    private bool isAttacking;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [Header("Interaction & Attack Settings")]
    [SerializeField] private Vector2 actionRange;
    [SerializeField] private float attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rbody.velocity = moveSpeed * moveDirection;
    }

    private void CheckInteractions()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, actionRange, 0, Vector2.zero);

        if(hits.Length < 1)
        {
            return;
        }

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.GetComponent<Interactible>())
            {
                hit.transform.GetComponent<Interactible>().Interact();
                return;
            }
        }
    }

    private IEnumerator CheckAttacks()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, actionRange, 0, Vector2.zero);
        if (hits.Length < 1)
        {
            yield return new WaitForSeconds(0);
        }
        else
        {
            canAttack = false;
            isAttacking = true;

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.GetComponent<Attackable>())
                {
                    hit.transform.GetComponent<Attackable>().Attack();
                }
            }

            yield return new WaitForSeconds(attackCooldown);
            isAttacking = false;
            canAttack = true;
        }
    }

    private void SetDirection(int mainComponent)
    {
        if(mainComponent > 0)
        {

            if(mainComponent == 1)
            {
                //-x
            }
            else
            {
                //x
            }
        }
        else
        {

            if (mainComponent == -2)
            {
                //-y
            }
            else
            {
                //y
            }
        }
    }

    private int MainComponent(Vector2 moveInput)
    {
        float xInput = Mathf.Abs(moveInput.x);
        float yInput = Mathf.Abs(moveInput.y);

        if(xInput == yInput && xInput == 0)
        {
            return currDirection;
        }

        if(xInput > yInput)
        {
            if(moveInput.x < 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        } 
        else
        {
            if (moveInput.y < 0)
            {
                return -2;
            }
            else
            {
                return -1;
            }
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (isAttacking)
        {
            return;
        }

        moveDirection = context.ReadValue<Vector2>();
        currDirection = MainComponent(moveDirection);
        //Set Sprite Direction
        SetDirection(currDirection);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started && canAttack)
        {
            StartCoroutine(CheckAttacks());
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CheckInteractions();
        }
    }
}
