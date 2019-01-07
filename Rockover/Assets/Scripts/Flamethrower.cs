using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour {
    private Animator anim;
    private CapsuleCollider2D S_Collider;
    public int damage; 
    
	// Use this for initialization
	void Start () {
        anim = GetComponent < Animator>();
        S_Collider = GetComponent<CapsuleCollider2D>();
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        EnableCollider(); 
	}

    void EnableCollider()
    {
        if(this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Fire_Active"))
        {
            //Toggle the Collider on and off 
            S_Collider.enabled = true;

           
        } else
        {
            S_Collider.enabled = false;
        }
    }
}
