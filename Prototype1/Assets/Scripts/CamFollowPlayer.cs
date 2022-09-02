using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 2 | Prototype 1
 * Description: Camera follows car(player)
*/
public class CamFollowPlayer : MonoBehaviour
{
    // drag the player onto this reference in the Inspector
    public GameObject player;

    private Vector3 offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
