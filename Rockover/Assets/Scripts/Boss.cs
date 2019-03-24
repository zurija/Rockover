using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Character {

    Rigidbody2D myRb;
    [SerializeField] public Slider healthBar;
    [SerializeField] public float damage; 

	// Use this for initialization
	public override void Start () {
      
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        healthBar.value = EnemyHealth; 
	}

   
}
