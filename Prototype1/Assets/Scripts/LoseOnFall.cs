using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add this using statement when using Text UI elements
// using UnityEngine.UI;

// Attach this script to the player

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
