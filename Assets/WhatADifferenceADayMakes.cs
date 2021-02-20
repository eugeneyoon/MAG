using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatADifferenceADayMakes : MonoBehaviour
{
    public float timeSpeed;
    public GameObject player;
    public float playerTimePos;

    // Update is called once per frame
    void Update()
    {
        // from TYWM
        //float verticalInput = Input.GetAxis("Vertical");
        //if (verticalInput > 0)
        //{
        //    transform.Rotate(Vector3.right, Mathf.Abs(verticalInput) * Time.deltaTime * timeSpeed);
        //}
        //if (verticalInput < 0)
        //{
        //    transform.Rotate(Vector3.left, Mathf.Abs(verticalInput) * Time.deltaTime * timeSpeed);
        //}

        // okay. so it's about 720 units on the z coord from beginning to end
        // it's about 120 degrees rotation for day to night
        // i need to make the directional light move 1/6 units every time the player moves 1 unit. 
        // so i need to set the directional light rotation = the player transform.z / 6. 
        transform.localEulerAngles = new Vector3((player.transform.position.z / 6) + 8, 300, 0);
    }
}
