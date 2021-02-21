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

    bool canDash = true;
    public float dashDuration;
    public float dashForce;

    public bool shielding = false;
    public GameObject shield; 
    public float shieldDurability;
    public GameObject hitShield;

    public AudioClip dashSound;
    private AudioSource dash;

    Vector3 worldGravity;

    void Start()
    {
        worldGravity = Physics.gravity;
        dash = GetComponent<AudioSource>();
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            speed *= 5; 
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            speed /= 5; 
        }

        // dash
        if (Input.GetButtonDown("Fire2"))
        {
            if (canDash)
            {
                StartCoroutine(Dash());
                dash.PlayOneShot(dashSound, 1.0f);
            }
        }

        // shield
        if (Input.GetButton("Fire1"))
        {
            if (shieldDurability > 0)
            {
                Shielding();
            }
            else
            {
                NotShielding();
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            NotShielding();
        }

        // time manipulation. 
        // if i'm moving, time is moving. 
        if (x != 0 || z != 0)
        {
            Time.timeScale = 1;
            //Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Time.timeScale = 0.01f;
            //Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    private IEnumerator Dash()
    {
        float timeLeft = dashDuration;
        canDash = false;
        Debug.Log("before");
        while (timeLeft > 0)
        {
            Vector3 move = (transform.right * x + transform.forward * z).normalized;
            controller.Move(move * dashForce * Time.deltaTime);
            timeLeft -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSecondsRealtime(1);
        canDash = true;
        Debug.Log("after");
    }

    // needs to be in player movement bc i'm toggling the shield on and off. 
    void Shielding()
    {
        // make the player invincible
        shielding = true;

        // make the shield visually
        shield.SetActive(true);

        // start counting down
        shieldDurability -= 10 * Time.deltaTime;

        // somewhere else, make it so that the countdown goes down more every time you get hit
        // maybe there's a way to get more of this too via pickup
    }

    void NotShielding()
    {
        shielding = false;
        shield.SetActive(false);
    }

    private void FixedUpdate()
    {
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
            speed *= 10;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            speed /= 10;
        }
    }
}
