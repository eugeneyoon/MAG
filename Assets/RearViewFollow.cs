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
        transform.LookAt(target);
    }
}
