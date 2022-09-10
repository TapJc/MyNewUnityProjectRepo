using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 2 | Challenge 2
 * Description: Detects collisions between the dog and ball and destroys the ball when they collide
 */ 
public class DetectCollisionsX : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("Dog").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        displayScoreScript.score++;
    }
}
