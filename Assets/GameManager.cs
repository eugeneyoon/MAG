using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        if (FindObjectOfType<PlayerMovement>().shielding == false)
        {
            Debug.Break();
        }   
    }
}
