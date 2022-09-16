using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 4 | Prototype 3
 * Description: Loops the background 
 */
public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Save the starting position of the background to a Vector3 variable
        startPosition = transform.position;

        // set the repeatWidth to half of the width of the background using boxCollider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // If the background is further to the left than the repeatWidth, reset it to its startPosition
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
