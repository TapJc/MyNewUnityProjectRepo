using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach to the food projectile prefab

/*
 * Brian Sida
 * Assignment 2 | Prototype 2
 * Description: Detects collisions between the animal and food and they both get destroyed
 */ 
public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
