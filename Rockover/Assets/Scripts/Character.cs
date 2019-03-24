using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour {
    public Animator MyAnimator;
    [SerializeField] public float movementSpeed;
    protected bool facingRight;
    [SerializeField] public float EnemyHealth;
    [SerializeField] private Slider mySlider;
    [SerializeField] private GameObject DeathEffect;
    
    

    // Use this for initialization
    public virtual void Start () {
        MyAnimator = GetComponent<Animator>();
        facingRight = true;
        
    }

    public  void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        
    }
    public void ChangeDirectionPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;

        if (EnemyHealth < 0)
        {
            Die();
        }
    }

    void Die()
        
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(DeathEffect, 2f);
        switch (gameObject.tag)
        {
            case "Paparazzi":
                GetComponent<Paparazzi>().effectImage.enabled = false;
                break;
            case "Boss":
                mySlider.gameObject.SetActive(false);
                break;
        }
        Destroy(gameObject);
        
    }

}
