using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;

    public float fowardInput;
    public float horizontalInput;

 
    // Update is called once per frame
    void Update()
    {
        fowardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Move forward
        // transform.Translate(0, 0, 1);

        // Which is the same as...
        // transform.Translate(Vector3.forward);

        // Move forward 20 meters / second if speed is set to 20
        transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);

        // Move player side-to-side with horizontal input
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
