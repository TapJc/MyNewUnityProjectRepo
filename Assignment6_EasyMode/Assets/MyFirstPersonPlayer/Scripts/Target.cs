using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 6
 * Description: Creates health and die methods for Target children 
*/
public abstract class Target : MonoBehaviour, IDamageable
{
    protected float health;

    public abstract void TakeDamage(float amount);

}
