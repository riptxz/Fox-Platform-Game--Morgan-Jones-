using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    LayerMask groundLayerMask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            print("Enemy has collided with Ground layer");
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
        
    }
}
