using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    private Rigidbody2D rbody;
    private Animator anim;
    private int currDirection;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;

    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            anim.SetBool(AnimationStrings.isMoving, value);

        }
    }

    private bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {

            _isFacingRight = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(Vector2 value)
    {
        IsMoving = value.magnitude != 0;

        rbody.MovePosition(rbody.position + value * moveSpeed);
        anim.SetFloat(AnimationStrings.horizontal, value.x);
        anim.SetFloat(AnimationStrings.vertical, value.y);
        SetFacingDirection(value.x);
    }
    private void SetFacingDirection(float value)
    {
        if (value > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (value < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }
}
