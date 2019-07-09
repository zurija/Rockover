using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Character {

    
    [SerializeField] public Slider healthBar;
    [SerializeField] public float damage; 

	
	// Update is called once per frame
	void FixedUpdate () {
        if(healthBar != null)
            healthBar.value = EnemyHealth; 
	}

   
}
