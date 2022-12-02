using UnityEngine;
using System.Collections;
using UnityEngine.AI;
/*
 * Brian Sida
 * Assignment 9
 * Description: Moves object to where player clicks in game
 */

public class MoveToClickPoint : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                agent.destination = hit.point;
            }
        }
    }
}
