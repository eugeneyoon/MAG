using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 obstacleDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        obstacleDirection = new Vector3(0, 1, -0.5f);
        rb.AddForce(obstacleDirection * 20000f, ForceMode.Impulse);    
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 0 || transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.x == 0 && rb.velocity.y == 0 && rb.velocity.z == 0)
        {
            gameObject.layer = 8;
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
