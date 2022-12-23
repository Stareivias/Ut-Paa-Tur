using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    public Animator animator;
    SpriteRenderer spriteRenderer;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("MainPerson").GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ///Moving
        horizontal = Input.GetAxisRaw("Horizontal");
        //Flip();

        ///Jumping
       
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (horizontal != 0)
        {
            animator.SetBool("IsMovingE", true);
        }
        else
        {
            animator.SetBool("IsMovingE", false);
        }

        

    }

    private void FixedUpdate()
    {
        ///Moving
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        FlipHandler();
    }

    //Jumping
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void FlipHandler()
    {
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
    }


    /// Moving
    /*private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }*/
}
