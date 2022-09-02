using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add this using statement when using Text UI elements
// using UnityEngine.UI;

// Attach this script to the player
/*
 * Brian Sida
 * Assignment 2 | Prototype 1
 * Description: Updates score when trigger zone is driven through
*/
public class PlayerEnterTrigger : MonoBehaviour
{
    // Set this reference in the Inspector
    // public Text textbox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
        }
    }
}
