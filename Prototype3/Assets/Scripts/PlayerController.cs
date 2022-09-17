using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 4 | Prototype 3
 * Description: Gives player the ability to jump
 */
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        // Set a reference to our RigidBody component
        rb = GetComponent<Rigidbody>();

        // Set the reference to animator component
        playerAnimator = GetComponent<Animator>();

        // Set reference to audio source component
        playerAudio = GetComponent<AudioSource>();

        // Modify gravity
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

        // Start Running
        playerAnimator.SetFloat("Speed_f", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Press spacebar to jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            // Set the trigger to play the jump animation
            playerAnimator.SetTrigger("Jump_trig");

            // Stop playing dirt particle
            dirtParticle.Stop();

            // Play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;

            // Play dirt particle
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            // Play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            // Play explosion particle
            explosionParticle.Play();

            // Play crash sound effect
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
    }
}
