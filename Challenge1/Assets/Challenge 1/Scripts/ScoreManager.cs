using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Brian Sida
 * Assignment 2 | Challenge 1
 * Description: Determines if player has won or lost the game 
*/
public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;

    // Set this in the Inspector 
    public Text textbook;

    // Initializes/Updates varibles when restarting
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbook.text = "Score: " + score;
        }

        // Win Condition: 5 or more points
        if (score >= 5)
        {
            won = true;
            gameOver = true;
        }

        if (gameOver)
        {
            if (won)
            {
                textbook.text = "You win!\nPress R to Try Again!";
            }
            else
            {
                textbook.text = "You lose!\nPress R to Try Again!";
            }

            // Restarts Game
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
