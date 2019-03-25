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
    [SerializeField] private GameObject BossPrefab;
    [SerializeField] private float minSize;

    
    

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
                if(transform.localScale.y > minSize)
                {

                    GameObject clone1 = Instantiate(BossPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
                    GameObject clone2 = Instantiate(BossPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
                    clone1.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
                    clone1.GetComponent<Character>().EnemyHealth = 100;
                    clone2.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
                    clone2.GetComponent<Character>().EnemyHealth = 100;
                }
                break;
        }
        Destroy(gameObject);
        
    }

}
