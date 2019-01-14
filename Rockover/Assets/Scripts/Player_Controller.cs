using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {
    //references
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    [SerializeField] private Transform[] groundPoints;
    [SerializeField] private LayerMask whatIsGround;
   

    //floats
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float groundRadius;
    [SerializeField] private float jumpForce;

    //boooleans
    private bool Jumping;
    private bool facingRight;
    private bool grounded;
    [SerializeField] private bool airControl;

    //PlayerCount
    private int Schallplatten_count;
    [SerializeField] Text countText;

    // Use this for initialization
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        facingRight = true;

        //counts
        Schallplatten_count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        HandleInput();

        HandleMovement(horizontal);

        HandleLayers();

        grounded = isGrounded();

        Flip(horizontal);

        ResetValues();
    }

    private void HandleInput() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jumping = true;
        }
    }

    private void HandleMovement(float horizontal) {
        if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("PlayerJump") && (grounded || airControl)) {
           myRigidbody.velocity =  new Vector2(horizontal * MovementSpeed * Time.deltaTime, myRigidbody.velocity.y);  
           Debug.Log(myRigidbody.drag);
        }
        if (grounded && Jumping) {
            grounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce*Time.deltaTime));
            myAnimator.SetTrigger("Jump");
            myRigidbody.velocity = Vector2.zero; 
        } 
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal) {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void ResetValues() {
        Jumping = false;
    }

    private bool isGrounded() {
        if (myRigidbody.velocity.y <= 0) {
            foreach (Transform point in groundPoints) {
                Collider2D[] Colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < Colliders.Length; i++) {
                    if (Colliders[i].gameObject != gameObject) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers() {
        if (!grounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }


    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Schallplatte") || other.gameObject.CompareTag("Schallplatte_g") || other.gameObject.CompareTag("Schallplatte_p"))
        {
            Destroy(other.gameObject);
            if (other.gameObject.CompareTag("Schallplatte"))
            {
                Schallplatten_count = Schallplatten_count + 1;
            }
            if (other.gameObject.CompareTag("Schallplatte_g"))
            {
                Schallplatten_count = Schallplatten_count + 5;
            }
            if (other.gameObject.CompareTag("Schallplatte_p"))
            {
                Schallplatten_count = Schallplatten_count + 10;
            }
            SetCountText();
        }


    }
    void SetCountText()
    {
        countText.text = "Schallplatten: " + Schallplatten_count.ToString();
    }
}
