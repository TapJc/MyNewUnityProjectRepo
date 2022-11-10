using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add this using statement when using Text UI elements
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Brian Sida
 * Assignment 7 | Prototype 4
 * Description: Determines if player has won or lost the game 
*/
public class ScoreManager : MonoBehaviour
{
    // Notice public static variables can be accessed from any script 
    // but cannot be seen in the Inspector
    public static bool gameOver;
    public static bool won;
    public static bool beginGame;

    // Set this in the Inspector 
    public Text textbook;

    // Initializes/Updates varibles when restarting
    void Awake()
    {
        gameOver = false;
        won = false;
        beginGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!beginGame)
        { 
            textbook.text = "Survive 10 waves and win." +
                "\nMake sure not to fall off the map, or you'll end up losing." +
                "\nPress spacebar to start.";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                beginGame = true;
            }
        }

        if (!gameOver && beginGame)
        {
            textbook.text = "Wave " + SpawnManager.waveNumber;
        }

        // Win Condition: Pass wave 10
        if (SpawnManager.waveNumber > 10)
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

