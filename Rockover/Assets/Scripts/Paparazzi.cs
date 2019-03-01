using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paparazzi : MonoBehaviour {

    Rigidbody2D myRigibody;
    Animator myAnimator;
    [SerializeField] float speed;
    [SerializeField] Transform player;
    [SerializeField] float distance;
    [SerializeField] Image effectImage;
    [SerializeField] float flashSpeed;
    public int health = 100; 

    // Use this for initialization
    void Start () {
        myRigibody = GetComponent<Rigidbody2D> ();
        myAnimator = GetComponent<Animator> ();
        effectImage.enabled = false; 
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        PaparazziMove();
        takePhoto();
	}

    void PaparazziMove()
    {
        //myRigibody.velocity = new Vector2(speed * Time.deltaTime, 0);
       //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    

    public void takePhoto()
    {
        if (Vector3.Distance(transform.position, player.position) < distance)
        {
            effectImage.enabled = true;


        }
        else effectImage.enabled = false; 
         //sound
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

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

