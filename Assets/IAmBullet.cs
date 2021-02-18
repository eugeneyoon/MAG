using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmBullet : MonoBehaviour
{
    public Rigidbody rb;
    public Transform playerPos;
    public float projectionForce;
    public Transform mouseLookPos;

    void Awake()
    {
        // this is not working 
        mouseLookPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
        // this vector has to be forward relative to when it spawns. but it just goes forward globally 
        rb.AddForce(Vector3.forward * projectionForce * Time.deltaTime, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        // destroy if certain distance away from player
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        float distance = Vector3.Distance(playerPos.transform.position, gameObject.transform.position);
        if (distance > 20)
        {
            Destroy(gameObject);
        }
    }
}
