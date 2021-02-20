using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 spawnDirection;
    private Vector3 obstacleDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnDirection = new Vector3(0, 1, -0.5f);
        rb.AddForce(spawnDirection * 20000f, ForceMode.Impulse);    
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 0 || transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        obstacleDirection = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // i think this is working? stuff turns into ground when it's slowed. 
        if (rb.velocity.x > -0.4 && rb.velocity.x < 0.4 || rb.velocity.y > -0.4 && rb.velocity.y < 0.4 || rb.velocity.z > -0.4 && rb.velocity.z < 0.4)
        {
            rb.velocity = new Vector3(0, 0, 0);
            gameObject.layer = 8;
            gameObject.tag = "Rest";
            rb.mass *= 100000;
        }
        else if (gameObject.tag == "Obstacle" && collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        // if obstacle or still obstacle hits shield 
        if (gameObject.tag == "Obstacle" && collision.collider.CompareTag("Shield") || gameObject.tag == "Rest" && collision.collider.CompareTag("Shield"))
        {
            GameObject golem = FindObjectOfType<CollisionDetection>().gameObject;
            CollisionDetection golemDetection = FindObjectOfType<CollisionDetection>();
            golem.transform.localScale -= new Vector3(golemDetection.golemEatSpeed / 2, golemDetection.golemEatSpeed / 2, golemDetection.golemEatSpeed / 2);

            // can't get smaller than 1 
            if (golem.transform.localScale.x < 1)
            {
                golem.transform.localScale = new Vector3(1, 1, 1);
            }

            Destroy(gameObject);

            //// this feels like stupid code
            //GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
            //rb.AddForce((transform.position - player.transform.position) * 10000, ForceMode.Impulse);
        }
    }
}
