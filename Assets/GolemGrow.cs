using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemGrow : MonoBehaviour
{
    private float x;
    private float z;

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        if (x == 0 || z == 0)
        {
            gameObject.transform.localScale += new Vector3(5, 5, 5) * Time.fixedDeltaTime;
        }
    }
}
