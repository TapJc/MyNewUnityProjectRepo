using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 7 | Prototype 4
 * Description: Implements player movement and interactions with level
*/
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private float forwardInput;

    private GameObject focalPoint;

    public bool hasPowerUp;
    private float powerupStrength = 15.0f;

    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        // move our powerup indicator to the ground below our player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }

    private void FixedUpdate()
    {
        /*
        playerRb.AddForce(Vector3.forward * speed * forwardInput);
        */

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        if (transform.position.y < -10)
        {
            ScoreManager.gameOver = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);

            // get a local reference to the enemy;
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // set a Vector3 with a direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            // add force away from player;
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }
    }

}
