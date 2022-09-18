﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 4 | Challenge 3
 * Description: Controls player movement 
 */
public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private bool isLowEnough = true;
    private Rigidbody playerRb;

    private UIManager uIManager;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;
    

    // Start is called before the first frame update
    void Start()
    {
        // Set a reference to our RigidBody component
        playerRb = GetComponent<Rigidbody>();

        // Set a reference to our uIManager component
        uIManager = GameObject.FindObjectOfType<UIManager>();

        // Set reference to audio source component
        playerAudio = GetComponent<AudioSource>();

        // Modify gravity
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        isLowEnough = true;

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            uIManager.score++;
        }

        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 15, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

        if (other.gameObject.CompareTag("SkyTrigger"))
        {
            isLowEnough = false;
        }
    }

}
