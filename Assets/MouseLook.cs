using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Transform playerBody;
    float xRotation = 10.421f;
    float yPosition = 1.51f;
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
        xRotation = Mathf.Clamp(xRotation, 5f, 25f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // scoop motion? this is not working. 
        yPosition *= mouseY;
        yPosition = Mathf.Clamp(yPosition, 10f, 20f);
        transform.position = Vector3.down * yPosition;

        // rearview mirror 
        if (Input.GetButtonDown("Fire3"))
        {
            rearView.SetActive(true);
            // i can put a clamp here for the sideways rotation. 
            // actually i think it's much simpler. just manually clamp the mouseX. 
            Debug.Log(mouseX);
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            rearView.SetActive(false);
        }
    }
}
