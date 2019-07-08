using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paparazzi : Character {

 
    public GameObject Target;
    [SerializeField] private float distance;
    [SerializeField] public Image effectImage;
    private IPaparazziState CurrentState;


    // Use this for initialization
    public override void Start () {
        base.Start();
        
        ChangeState(new PatrolState());
        effectImage.enabled = false; 
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        CurrentState.Execute();
        PaparazziMove();
        LookAtTarget();
    }
   private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;
            if(xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    } 
    
    public void PaparazziMove()
    {
        transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
    }

    public Vector2 GetDirection()
    {

        return facingRight ? Vector2.right : Vector2.left;
    }
    public void ChangeState(IPaparazziState NewState)
    {
        if(CurrentState != null)
        {
            CurrentState.Exit();
        }
        CurrentState = NewState;
        CurrentState.Enter(this);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        CurrentState.OnTriggerEnter(other);
    }
}

