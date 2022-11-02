using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Brian Sida
 * Assignment 6
 * Description: Handles weapon mechanics
*/
public class ShootWithRaycasts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;

    public ParticleSystem muzzleFlash;

    public float hitForce = 10f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hitInfo;

        // if we hit something with out ray..
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

            // get the target script off the hit object
            SmallBox smallBox = hitInfo.transform.gameObject.GetComponent<SmallBox>();

            WallBarrier wallBarrier = hitInfo.transform.gameObject.GetComponent<WallBarrier>();

            // if the target script is found, make the target take damage
            if (smallBox != null) 
            {
                smallBox.TakeDamage(damage);
            }
            else if(wallBarrier != null)
            {
                wallBarrier.TakeDamage(damage);
            }

            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
