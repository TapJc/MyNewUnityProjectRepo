using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 7 | Challenge 4
 * Description: Implements enemy behavior
*/
public class EnemyX : MonoBehaviour
{
    private float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private int enemyGoals;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("Player Goal");
        speed = SpawnManagerX.enemySpeed * 50;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
            enemyGoals++;
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

        if (SpawnManagerX.waveCount == enemyGoals)
        {
            ScoreManager.gameOver = true;
        }
    }

}
