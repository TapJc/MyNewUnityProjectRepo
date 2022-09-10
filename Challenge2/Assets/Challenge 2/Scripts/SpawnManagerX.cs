using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 2 | Challenge 2
 * Description: Spawns the balls above the player at random times
 */
public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    public HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBallWithCoroutine());

        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    IEnumerator SpawnRandomBallWithCoroutine()
    {
        // This adds a 3 second delay before the first prefab spawns
        yield return new WaitForSeconds(1.5f);

        // Continues to spawn while the game is not over. Make condition true to gameOver.
        while (!healthSystem.gameOver)
        {
            // Instead of copy-pasting, call the encapsuled method already written
            SpawnRandomBall();

            float randomDelay = Random.Range(3.0f, 5.0f);

            // This waits for 1.5 seconds before continuing the while loop
            yield return new WaitForSeconds(randomDelay);
        }
    }
        // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

            // Generate index
            int prefabIndex = Random.Range(0, ballPrefabs.Length);

            // instantiate ball at random spawn location
            Instantiate(ballPrefabs[prefabIndex], spawnPos, ballPrefabs[prefabIndex].transform.rotation);
    }
}

