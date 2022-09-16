using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 4 | Prototype 3
 * Description: Moves obstacles to the left and destroys them once out of bounds
 */
public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;

    private PlayerController playerControllerScript;

    private float leftBound = -15f;

    private void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Destroy obstacles out of bounds off screen to the left 
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
