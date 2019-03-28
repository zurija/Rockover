using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingBehaviour : StateMachineBehaviour {

    public float timer;
    public float minTime;
    public float maxTime;

    public Transform playerPos;
    [SerializeField] private float speed;
    public Rigidbody2D rb;
    [SerializeField] private float JumpForce;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GameObject.FindGameObjectWithTag("Boss").GetComponent<Rigidbody2D>();
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("Talking");
        }
        else
        {
            timer -= Time.deltaTime;
        }
        rb.AddForce(new Vector2(0, JumpForce * Time.deltaTime));

        Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	
}
