using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add this script to the food and animal prefabs
public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private HealthSystem healthSystemScript;

    private void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Separating the food from the animals going out of bounds 
        // Food goes out of bounds
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        // Animals going out of bounds
        if (transform.position.z < bottomBound)
        {
            // Grab the health system script and call takeDamage()
            healthSystemScript.TakeDamage();

            Destroy(gameObject);
        }
    }
}
