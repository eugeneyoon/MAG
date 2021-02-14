using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnBoundX;
    public float spawnBoundY;
    public float spawnBoundZ;
    public float difficultyRiser;

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
        while (difficultyRiser > 0.1f)
        {
            SpawnChallenge();
            difficultyRiser *= 0.9f;
            yield return new WaitForSeconds(difficultyRiser);
        }
        while (difficultyRiser > 0)
        {
            SpawnChallenge();
            yield return new WaitForSeconds(difficultyRiser);
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
