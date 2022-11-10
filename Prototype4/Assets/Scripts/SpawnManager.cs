using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 7 | Prototype 4
 * Description: Spawns enemy and powerUp in random locations in level
*/
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9;

    public int enemyCount;
    public static int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp(1);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        if (!ScoreManager.gameOver && ScoreManager.beginGame)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                // instantiate the enemy in the random position
                Instantiate(enemyPrefab, GeneratesSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
    }

    private void SpawnPowerUp(int powerUpsToSpawn)
    {
        if (!ScoreManager.gameOver && ScoreManager.beginGame)
        {
            for (int i = 0; i < powerUpsToSpawn; i++)
            {
                // instantiate the enemy in the random position
                Instantiate(powerUpPrefab, GeneratesSpawnPosition(), powerUpPrefab.transform.rotation);
            }
        }
    }

    private Vector3 GeneratesSpawnPosition()
    {
        // Generating a random position on the platform
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (ScoreManager.beginGame)
        {
            if (enemyCount == 0 && !ScoreManager.gameOver)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                SpawnPowerUp(1);
            }
        }
    }
}
