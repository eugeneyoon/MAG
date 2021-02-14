using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemGrow : MonoBehaviour
{
    private float x;
    private float z;
    public float golemGrowSpeed;

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        // if player is not moving
        if (x == 0 && z == 0)
        {
            gameObject.transform.localScale += new Vector3(golemGrowSpeed, golemGrowSpeed, golemGrowSpeed) * Time.deltaTime;
        }
    }
}
