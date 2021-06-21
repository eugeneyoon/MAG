using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Transform playerBody;
    float xRotation = 10.421f;
    float yRotation; 
    float yPosition = 1.51f;
    public GameObject rearView;
    public GameObject player;

    // from yt https://www.youtube.com/watch?v=xcn7hz7J7sI
    private Vector3 cameraOffset; 

    void Start()
    {
        // brackeys code to hide cursor
        Cursor.lockState = CursorLockMode.Locked;

        // yt
        cameraOffset = transform.position - playerBody.position; 
    }

    void Update()
    {
        // oh nice. unscaledDeltaTime was the key to making it not affected by timescale. 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.unscaledDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.unscaledDeltaTime;

        playerBody.Rotate(Vector3.up * mouseX); // this moves the player object? 

        // brackeys math to make clamp work. nice. 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 5f, 25f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // scoop motion? this is not working. 
        //yPosition *= mouseY;
        //yPosition = Mathf.Clamp(yPosition, 10f, 20f);
        //transform.position = Vector3.down * yPosition;

        // now that the camera is separated, i need to make it follow the player. 
        //gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.51f, player.transform.position.z - 5);

        // i just copied the above code. i don't think this will work. LOL
        //gameObject.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
        // okay this just rotates around the 0,0,0,0 of the camera. need to rotation around the player. 
        // just use look at? 
        //transform.LookAt(playerBody);
        // doesn't work. 
        // let's try to modify the brackeys code.  below
        //xRotation -= mouseY;
        //yRotation -= mouseX;
        //xRotation = Mathf.Clamp(xRotation, 5f, 25f);
        //transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        // okay this works but again it's just going around its own 0,0,0,0. duh because that's what i'm telling it to do. 


        // and then only follow y axis when not jumping

        // also i should still be able to turn. 

        // yt
        Vector3 newPos = playerBody.position + cameraOffset; 
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 5.0f, Vector3.up);
        transform.position = Vector3.Slerp(transform.position, newPos, 0.5f);


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
