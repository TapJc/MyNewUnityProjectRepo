using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
        }
    }
}
