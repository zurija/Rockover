using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
    public Animator MyAnimator { get; private set; }
    [SerializeField] public float movementSpeed;
    protected bool facingRight;
    
    

    // Use this for initialization
    public virtual void Start () {
        MyAnimator = GetComponent<Animator>();
        facingRight = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public  void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

}
