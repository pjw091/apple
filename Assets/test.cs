using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public float speed;

    public float checkDistance = 0.55f;

    public int jumpCount = 0;


    bool isJumping = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Time.deltaTime * Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Time.deltaTime * Vector3.left * speed;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, LayerMask.GetMask("Ground"));
        isJumping = hit.collider == null;

        if (!isJumping)
        {
            jumpCount = 0;
        }

        Debug.DrawRay(transform.position, Vector2.down * checkDistance, Color.red);

        if (!isJumping == false || jumpCount < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
             rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
             jumpCount += 1;
                
            }

        }

    }

}

