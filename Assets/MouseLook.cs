using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Transform playerBody;
    float xRotation = 0f;
    public GameObject rearView; 

    void Start()
    {
        // brackeys code to hide cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // oh nice. unscaledDeltaTime was the key to making it not affected by timescale. 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.unscaledDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.unscaledDeltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        // brackeys math to make clamp work. nice. 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // rearview mirror 
        if (Input.GetButtonDown("Fire3"))
        {
            rearView.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            rearView.SetActive(false);
        }
    }
}
