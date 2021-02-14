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
            gameObject.tag = "Ground";
            rb.mass *= 10000;
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Break();
            }
        }
    }
}
