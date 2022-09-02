using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach script to a Trigger Zone
/*
 * Brian Sida
 * Assignment 2 | Prototype 1
 * Description: Updates the score once whenever the car drives through the trigger zone
*/
public class TriggerZoneAddScoreOnce : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.score++;
        }
    }
}
