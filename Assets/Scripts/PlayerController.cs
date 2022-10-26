using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    private bool isGrounded;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    public bool isTurned;

    public GameObject Scope;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerAnimation();
        TurnPlayer();
    }

    private void PlayerMovement()
    {
        //Moveing

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
        }

        //Jumping

        isGrounded = Physics2D.OverlapPoint(groundCheckpoint.position, whatIsGround);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }

    private void PlayerAnimation()
    {
        animator.SetBool("isGrounded", isGrounded);

        if(isTurned)
        {
            animator.SetFloat("moveSpeed", -1 * rigidbody.velocity.x);
        }
        else
        {
            animator.SetFloat("moveSpeed", rigidbody.velocity.x);
        }
    }

    private void TurnPlayer()
    {
        float distance = transform.position.x - Scope.transform.position.x;

        if(distance >= 0)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            isTurned = true;
        }
        else if(distance <= 0)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            isTurned = false;
        }
    }
}
