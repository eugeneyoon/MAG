using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float gravity;
    Vector3 velocity;
    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //rotate from TYWM
        transform.Rotate(Vector3.back, 100 * Time.deltaTime);

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // following 
        Vector3 pos = target.position;
        if (x != 0 || z != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, 10 * Time.deltaTime);
        }
        else
        {
            gravity = 0;
        }

        velocity = transform.position;
        velocity.y += gravity * Time.deltaTime;
        transform.position = velocity;

        // this jank shit is to have it "be" on the ground. 
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        // so the above kind of works even though it's janky. but i need to make that gravity be the movement basically for all things. so then...
        // it actually needs to be a vector, not a float. maybe just grab the vector from playermovement? 
        // and i think i need rigidbodies so that i can store vectors and use then when i unfreeze time. 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Break();
        }
    }
}
