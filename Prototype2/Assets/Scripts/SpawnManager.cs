using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Drag the prefabs to spawn onto this array in the inspector
    public GameObject[] prefabsToSpawn;

    // Variables for Spawn Positions
    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    public HealthSystem healthSystem;

    private void Start()
    {
        // Get a reference to the health system script
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem >();

        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        // This adds a 3 second delay before the first prefab spawns
        yield return new WaitForSeconds(3f);

        // Continues to spawn while the game is not over. Make condition true to gameOver.
        while (!healthSystem.gameOver)
        {
            // Instead of copy-pasting, call the encapsuled method already written
            SpawnRandomPrefab();

            float randomDelay = Random.Range(1.5f, 3.0f);

            // This waits for 1.5 seconds before continuing the while loop
            yield return new WaitForSeconds(randomDelay);
        }
    }
    void SpawnRandomPrefab()
    {
        // Generate index
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        // Generate a spawn position
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        // Spawn
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);

    }
}
