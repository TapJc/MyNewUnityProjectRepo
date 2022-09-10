using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 2 | Challenge 2
 * Description: Gives the abilty for the player to shoot dogs and controls how many times the player can shoot them
 */
public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float time = 2.0f;
    public float timer = 0;

    private void Start()
    {
        timer = Time.time;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= time)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 0;
            }
        }
    }
}
