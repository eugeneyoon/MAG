using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearViewFollow : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Golem").transform;
    }

    void Update()
    {
        //if (gameObject.transform.rotation.y < 140)
        //{
        //    gameObject.transform.rotation = new Quaternion(0, 140, 0, 0);
        //}
        //if (gameObject.transform.rotation.y >220)
        //{
        //    gameObject.transform.rotation = new Quaternion(0, 200, 0, 0);
        //}
        transform.LookAt(target);
    }
}
