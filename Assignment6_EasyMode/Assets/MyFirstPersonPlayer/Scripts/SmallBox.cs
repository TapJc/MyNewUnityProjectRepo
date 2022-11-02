using UnityEngine;
using System.Collections;
using System;

/*
 * Brian Sida
 * Assignment 6
 * Description: Information concerning small box targets
*/
public class SmallBox : Target
{

    // Use this for initialization
    protected void Awake()
    {
        health = 30f;
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
