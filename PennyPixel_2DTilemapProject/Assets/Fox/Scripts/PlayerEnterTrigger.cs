using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEnterTrigger : MonoBehaviour
{
    public Text textbook;

    public GameObject gameOverText; 
    public bool gameOver = false;

    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerZone") && displayScoreScript.score >= 10)
        {
            gameOver = true;
            gameOverText.SetActive(gameOver);
            Debug.Log("You Win!!");

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
