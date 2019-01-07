using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paparazzi : MonoBehaviour {

    Rigidbody2D myRigibody;
    Animator myAnimator;
    [SerializeField] float speed; 

	// Use this for initialization
	void Start () {
        myRigibody = GetComponent<Rigidbody2D> ();
        myAnimator = GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        PaparazziMove();
	}

    void PaparazziMove()
    {
        myRigibody.velocity = new Vector2(speed * Time.deltaTime, 0);
    }
}
