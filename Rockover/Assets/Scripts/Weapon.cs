using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab; 
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        SoundManagerScript.PlaySound("PlayerFire");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
