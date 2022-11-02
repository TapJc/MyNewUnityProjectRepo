using UnityEngine;
using System.Collections;

/*
 * Brian Sida
 * Assignment 6
 * Description: Information concerning wall barriers
*/
public class WallBarrier : Target
{

    // Use this for initialization
    protected void Awake()
    {
        health = 80f;
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
