using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    Vector3 velocity;
    private Transform target;
    public float golemMoveSpeed;
    public float golemEatSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // following 
        if (x != 0 || z != 0)
        {
            rb.AddForce((target.position - transform.position) * golemMoveSpeed, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Break();
        }
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Rest"))
        {
            gameObject.transform.localScale += new Vector3(golemEatSpeed, golemEatSpeed, golemEatSpeed);
            Destroy(collision.collider.gameObject);
        }
    }
}
