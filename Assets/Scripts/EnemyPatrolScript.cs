using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrolScript : MonoBehaviour
{

    float xvel;
    Rigidbody2D rb;

    public LayerMask groundLayerMask;
    bool result;
    bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xvel = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if moving left, check left side of sprite
        if (xvel < 0) 
        {
            if (RayCollisionCheck(-0.5f, 0) == false)
            {                                                                       // changing direction when on the left edge
                xvel = -xvel;
            }
        }



        // if moving right, check right side of sprite
        if (xvel > 0) 
        {
            if (RayCollisionCheck(0.5f, 0) == false)
            {                                                                       // changing the direction when on the right edge
                xvel = -xvel;
            }
        }


        rb.linearVelocity = new Vector2(xvel, 0);
    }


    public bool RayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward starting at the sprite's position
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in th e editor to see these
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
