using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paparazzi : Character {

    Rigidbody2D myRigibody;
    [SerializeField] public GameObject Target;
    [SerializeField] Transform player;
    [SerializeField] float distance;
    [SerializeField] Image effectImage;
    [SerializeField] float flashSpeed;
    public int health = 100;
    private IPaparazziState CurrentState;

    // Use this for initialization
    public override void Start () {
        base.Start();
        myRigibody = GetComponent<Rigidbody2D> ();
        effectImage.enabled = false;
        ChangeState(new PatrolState());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        CurrentState.Execute();
        PaparazziMove();
        LookAtTarget();
        TakePhoto();
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

    

    public void TakePhoto()
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
         //sound
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        CurrentState.OnTriggerEnter(other);
    }
}

