using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add this using statement when using Text UI elements
using UnityEngine.UI;

/*
 * Brian Sida
 * Assignment 6
 * Description: Displays youWin text when player enter trigger zone
*/
public class PlayerEnterTrigger : MonoBehaviour
{
    public Text textbox;
    public GameObject youWonText;

    public bool gameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            gameOver = true;
            youWonText.SetActive(gameOver);
            Debug.Log("You Win");
        }
    }
}