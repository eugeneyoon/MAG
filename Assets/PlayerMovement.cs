using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -50f;
    public float jumpHeight = 3f;
    private float x;
    private float z; 

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask; 

    public Vector3 velocity;
    bool isGrounded;

    Vector3 worldGravity;

    void Start()
    {
        worldGravity = Physics.gravity;
    }

    void Update()
    {
        // so this is brackeys' ground check stuff. 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            // this is brackeys' forcing down to ground once player is near ground. 
            velocity.y = -2f; 
        }

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        // brackeys arrow that points the direction we want to move... but i don't understand it. 
        // does this make it so you can strafe? and be pressing w but change direction with mouse? 
        Vector3 move = (transform.right * x + transform.forward * z).normalized; // normalized fixes the faster diagonal. 
        controller.Move(move * speed * Time.deltaTime);

        // jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // physics equation for finding velocity required to jump a height i think? 
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // brackeys making gravity. time squared is reason for 2x deltatime
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // this makes movement speed up so should be used for like a powerup or something
        if (Input.GetButtonDown("Fire2"))
        {
            speed *= 5; 
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            speed /= 5; 
        }
    }

    private void FixedUpdate()
    {
        // time STOP
        if (x != 0 || z != 0)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            //Time.timeScale = 0;
            Time.timeScale = 0.01f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        // changing gravity. use in a different game i think 
        //Physics.gravity = worldGravity;
        //// worldGravity.y = velocity.y;

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    worldGravity.x = -9.8f;
        //    velocity.x += gravity * Time.fixedDeltaTime;
        //    Debug.Log(worldGravity);
        //}
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    worldGravity.x = 9.8f;
        //    velocity.x += gravity * Time.fixedDeltaTime;
        //    Debug.Log(worldGravity);
        //}
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            speed *= 10f;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            speed /= 10f;
        }
    }
}
