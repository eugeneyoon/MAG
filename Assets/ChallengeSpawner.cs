﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnBoundX;
    public float spawnBoundY;
    public float spawnBoundZ;
    public float startingRate;
    public float spawnRateMod; 
    public float spawnRateLimit;

    // Start is called before the first frame update
    void Start()
    {
        // spawn a bunch of random challenges
        // from unity tutorial
        //InvokeRepeating("SpawnChallenge", 1, repeat);
        StartCoroutine(Harder());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(difficultyRiser);
    }

    private IEnumerator Harder()
    {
        while (startingRate > spawnRateLimit)
        {
            SpawnChallenge();
            startingRate *= spawnRateMod;
            yield return new WaitForSeconds(startingRate);
        }
        while (startingRate > 0)
        {
            SpawnChallenge();
            yield return new WaitForSeconds(startingRate);
        }
    }

    void SpawnChallenge()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnBoundX, spawnBoundX), spawnBoundY, spawnBoundZ);

        // hmm mess with rotation? 
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
