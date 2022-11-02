using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 6
 * Description: Controls camera movement
*/
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public GameObject player;
    private float verticalLookRotation = 0f;

    // hide and lock the cursor to the center of the screen
    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Get mouse input and assign it two floats
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate player GameObject with horizontal mouse input
        player.transform.Rotate(Vector3.up * mouseX);

        // Rotate camera arount the x axis with vertical mouse input
        verticalLookRotation -= mouseY;
        // Clamp the rotation so the player does not over-rotate
        // and look behind themselves upside down
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        // Apply rotation based on the clamped input
        transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }
}
