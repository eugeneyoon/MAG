using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float pow;
    public Transform playerPos; 

    void Awake()
    {
        rb.AddForce(Vector3.forward * pow, ForceMode.Force);
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
