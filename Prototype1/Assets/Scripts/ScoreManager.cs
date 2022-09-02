using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add this using statement when using Text UI elements
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Notice public static variables can be accessed from any script 
    // but cannot be seen in the Inspector
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

        // Win Condition: 3 or more points
        if (score >= 3)
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
