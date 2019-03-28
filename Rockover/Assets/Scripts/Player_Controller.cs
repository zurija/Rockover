using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Controller : Character {
    //references
    private Rigidbody2D myRigidbody;
    
    [SerializeField] private Transform[] groundPoints;
    [SerializeField] private LayerMask whatIsGround;
  
    //floats
    
    [SerializeField] private float groundRadius;
    [SerializeField] private float jumpForce;
  

    //boooleans
    private bool Jumping;
    private bool grounded;
    [SerializeField] private bool AirControl;
    public bool hasBadge;

    //PlayerCount
    public int Schallplatten_count;
    [SerializeField] TextMeshProUGUI countText;

    //flashColor
   
    // Use this for initialization
    public override void Start() {
        base.Start(); 
        myRigidbody = GetComponent<Rigidbody2D>();
        hasBadge = false; 

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
        if (!MyAnimator.GetCurrentAnimatorStateInfo(0).IsTag("PlayerJump") && (grounded || AirControl)) {
           myRigidbody.velocity =  new Vector2(horizontal * movementSpeed * Time.deltaTime, myRigidbody.velocity.y);  
         
        }
        if (grounded && Jumping) {
            SoundManagerScript.PlaySound("PlayerJump"); 
            grounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce*Time.deltaTime));
            MyAnimator.SetTrigger("Jump");
            myRigidbody.velocity = Vector2.zero; 
        } 
        MyAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal) {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
            ChangeDirectionPlayer();
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
            MyAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            MyAnimator.SetLayerWeight(1, 0);
        }
    }


    

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case ("Schallplatte"):
                Schallplatten_count = Schallplatten_count + 1;
                Destroy(other.gameObject);
                break;
            case ("Schallplatte_g"):
                Schallplatten_count = Schallplatten_count + 5;
                Destroy(other.gameObject);
                break;
            case ("Schallplatte_p"):
                Schallplatten_count = Schallplatten_count + 10;
                Destroy(other.gameObject);
                break;
            case ("VIP"):
                other.gameObject.SetActive(false);
                hasBadge = true;
                break;
            case ("Drummer"):
                Debug.Log("jj");
                SceneManager.LoadScene("EndScene");
                break;
        }
        SetCountText();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.transform.tag == "MovePlatform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovePlatform")
        {
            transform.parent = null;
        }
    }


    void SetCountText()
    {
        countText.text = "Schallplatten: " + Schallplatten_count.ToString();
        if (Schallplatten_count >= 100)
        {
            Schallplatten_count = 0;
            gameObject.GetComponent<Player_HealthSystem>().CurLives += 1;
            gameObject.GetComponent<Player_HealthSystem>().SetHealthText();

        }
    }
}
