using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add this using statement when using Text UI elements
// using UnityEngine.UI;

// Attach this script to the player
/*
 * Brian Sida
 * Assignment 2 | Prototype 1
 * Description: Prompts a "Game Over" screen if player falls out of the road
*/
public class LoseOnFall : MonoBehaviour
{   
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1)
        {
            ScoreManager.gameOver = true;
        }
    }
}
