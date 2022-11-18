using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Brian Sida
 * Assignment 8 | Challenge 5
 * Description: Implements a timer 
*/
public class Timer : MonoBehaviour
{
    private GameManagerX gameManagerX;
    public TextMeshProUGUI timeLeftText;

    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerX>();
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);
        timeLeftText.text = "Timer: " + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerX.isGameActive)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                gameManagerX.GameOver();
            }
        }
    }
}
