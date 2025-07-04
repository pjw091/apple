using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float maxSpeed = 3f;
    public float checkDistance = 0.52f;
    bool isGrounded = false;
    bool isFalling = false;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if(move != 0)
        {
            spriteRenderer.flipX = (move == -1);
        }

        animator.SetBool("run", move != 0);

        rb.velocity = new Vector2(maxSpeed * move, rb.velocity.y);

        if(rb.velocity.y <= 0)
        {
            isFalling = true;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, LayerMask.GetMask("Ground"));
        isGrounded = hit.collider != null;
        animator.SetBool("IsGrounded", isGrounded);

        if (isGrounded && isFalling)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isFalling = false;
                rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);

                animator.SetTrigger("jump");
            }
        }
    }
}
