using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 moveDirection;
    private Rigidbody2D rbody;
    private int currDirection;

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject interactionTrigger;

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

    private void SetDirection(int mainComponent)
    {
        if(mainComponent > 0)
        {
            interactionTrigger.transform.localScale = new Vector2(1, 2);

            if(mainComponent == 1)
            {
                interactionTrigger.transform.localPosition = new Vector2(-1,0);
            }
            else
            {
                interactionTrigger.transform.localPosition = new Vector2(1,0);
            }
        }
        else
        {
            interactionTrigger.transform.localScale = new Vector2(2, 1);

            if (mainComponent == -2)
            {
                interactionTrigger.transform.localPosition = new Vector2(0,-1);
            }
            else
            {
                interactionTrigger.transform.localPosition = new Vector2(0,1);
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
        moveDirection = context.ReadValue<Vector2>();
        currDirection = MainComponent(moveDirection);
        SetDirection(currDirection);
        //Set Sprite Direction



    }
}
