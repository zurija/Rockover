using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HealthSystem : MonoBehaviour
{
    private int CurHealth;
    [SerializeField] private int MaxHealth;
    private Animator anim;
    [SerializeField] public int MaxLives;
    protected int CurLives;
    private int FlamethrowerDamage;
    [SerializeField] Text HealthStatText;
    [SerializeField] Transform spawnPoint;



    // Use this for initialization
    void Start()
    {
        CurHealth = MaxHealth;
        CurLives = MaxLives;
        anim = GetComponent<Animator>();
        GameObject Feuerwerfer = GameObject.Find("Feuerwerfer");
        FlamethrowerDamage= Feuerwerfer.GetComponent<Flamethrower>().damage;
        SetHealthText();
    }
    private void FixedUpdate()
    {
        playerHealthStats(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire")) {
            CurHealth = CurHealth - FlamethrowerDamage;
        }
       
       
       
    }
   
    void SetHealthText()
    {
        HealthStatText.text = "Leben: " + CurLives.ToString();
    }

    void playerHealthStats()
    {
        if (CurHealth == 0)
        {
            CurLives = CurLives - 1;
            CurHealth = MaxHealth;
            SetHealthText();
        }
        Debug.Log(CurHealth);
        Debug.Log(CurLives);

        if (CurLives == 0)
        {
            gameObject.transform.position = spawnPoint.position; 
            CurLives =  MaxLives;
            SetHealthText(); 
        }
    }

}
