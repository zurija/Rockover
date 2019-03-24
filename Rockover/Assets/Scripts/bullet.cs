using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    [SerializeField] private float speed = 20f;
    [SerializeField] public int damage = 20;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject hiteffect;
    private GameObject[] Sight;
    private BoxCollider2D[] SightCollider;
   

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
        Sight = GameObject.FindGameObjectsWithTag("Sight");
       /* for (int i = 0; i < Sight.Length; i++)
        {
            SightCollider[i] = Sight[i].gameObject.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), SightCollider[i], true);
        }
     foreach(GameObject human in Sight)
        {
            Debug.Log(human.name);
        } */
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
        Instantiate(hiteffect, transform.position, transform.rotation);
        Destroy(hiteffect, 2f);
        Destroy(gameObject);
        Debug.Log(hitInfo);
    }
    
}
