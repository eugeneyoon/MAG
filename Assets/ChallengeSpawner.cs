using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnBoundX;
    public float spawnBoundY;
    public float spawnBoundZ;

    // Start is called before the first frame update
    void Start()
    {
        // spawn a bunch of random challenges
        // from unity tutorial
        InvokeRepeating("SpawnChallenge", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        // spawn some depending on how far up the player is or something 
    }

    void SpawnChallenge()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnBoundX, spawnBoundX), spawnBoundY, spawnBoundZ);

        // hmm mess with rotation? 
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
