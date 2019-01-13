using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect; 

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed; 
	}

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /*hitInfo.GetComponent<Paparazzi>();
        if (Paparazzi != null)
        {
        Paparazzi.TakeDamage(damage);
        }*/
        Debug.Log(hitInfo);
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
