using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // just handling collision with shield. 

    public float shieldHitDuration;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Rest"))
        {
            Debug.Log("enter");
            //HitShield();
            FindObjectOfType<PlayerMovement>().hitShield.SetActive(true);
            FindObjectOfType<PlayerMovement>().shieldDurability -= 10;
        }
    }

    // ohhh there's no exit bc they get destroyed. 
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Rest"))
        {
            Debug.Log("exit");
            FindObjectOfType<PlayerMovement>().hitShield.SetActive(false);
        }
    }

    // i shouldn't need a coroutine here. also, i clearly don't know how to use them. 
    //private IEnumerator HitShield()
    //{
    //    float timeLeft = shieldHitDuration;
    //    while (timeLeft > 0)
    //    {
    //        FindObjectOfType<PlayerMovement>().hitShield.SetActive(true);
    //        timeLeft -= Time.deltaTime;
    //        yield return new WaitForSeconds(Time.deltaTime);
    //    }
    //    Debug.Log("coroutine");
    //}
}