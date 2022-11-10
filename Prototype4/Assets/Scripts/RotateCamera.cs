using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 7 | Prototype 4
 * Description: Handles camera movement
*/
public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
