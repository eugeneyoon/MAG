using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDrag : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 maxVelocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0 || z != 0)
        {
            rb.drag = 0;
            rb.angularDrag = 0.05f;
        }
        else
        {
            rb.drag = 30;
            rb.angularDrag = 30;
        }
    }
}
