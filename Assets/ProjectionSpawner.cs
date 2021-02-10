using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionSpawner : MonoBehaviour
{
    public GameObject projection;
    public Transform playerPos;
    public Transform mouseLookPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // shoot projection  
        if (Input.GetButtonDown("Fire1"))
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
            mouseLookPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
            spawnProjection();
        }
    }

    void spawnProjection()
    {
        Instantiate(projection, playerPos);
        //Debug.Log(playerPos.localEulerAngles.y);
        Debug.Log(playerPos);
    }
}
