using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;
   

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Paparazzi Paparazzi = hitInfo.GetComponent<Paparazzi>();
        if (Paparazzi != null)
        {
            Paparazzi.TakeDamage(damage);
        }
        Boss Boss = hitInfo.GetComponent <Boss>();
        if (Boss != null)
        {
            Boss.TakeDamage(damage);
        }
        Instantiate(Resources.Load("hitEffect"), transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log(hitInfo);
    }
    

}
