using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAiScript : MonoBehaviour
{

    public float speed;
    public Animator anim;
    public Transform moveSpot;
    private float waitTime;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public MoveSprite playerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waitTime = startWaitTime;
        
        moveSpot.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        print("Enemy says: The player has " + playerScript.playerLives + "lives");
       
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) >= 0.2f)
        {
            if (waitTime <= 0)                                                                                 // Patrolling at random points
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")                                                             // Resetting the scene when the player touches the enemy
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            if (collision.gameObject.tag == "Slime 2")
                print("This game object has collided with Slime 2");
        }
    }


    
   
}
