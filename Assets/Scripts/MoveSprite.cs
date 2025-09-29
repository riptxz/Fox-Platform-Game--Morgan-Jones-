using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoveSprite : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;

    public Animator anim;

    float xv, yv;
    bool isGrounded;
    bool isJumping;
    LayerMask groundLayerMask;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isJumping = false;

        groundLayerMask = LayerMask.GetMask("Ground");
    }


    public bool DoRayCollisionCheck()
    {
        float rayLength = 0.5f; // length of raycast


        //cast a ray downward 
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        return hit.collider;


    }






    // Update is called once per frame
    void Update()
    {
        float xvel, yvel;
        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (Input.GetKey("a"))
        {
            xvel = -3;
        }

        if (Input.GetKey("d"))
        {
            xvel = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yvel = 6f;
            isJumping = true;

        }
        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        anim.SetBool("isWalking", false);

        //do animation
        if (xvel < -0.1f || xvel > 0.1f)
        {
            anim.SetBool("isWalking", true);

        }

        //check for landing on the ground
        if (isJumping == true && isGrounded == true && yvel <= 0)
        {
            isJumping = false;
        }


        anim.SetBool("isJumping", isJumping);


        isGrounded = DoRayCollisionCheck();

        print("grounded=" + isGrounded);

     
        


    }

}

   
