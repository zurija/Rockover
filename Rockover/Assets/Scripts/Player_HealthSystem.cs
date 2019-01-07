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
    private int FlamethrowerDamage;
    [SerializeField] Text HealthStatText;


    // Use this for initialization
    void Start()
    {
        CurHealth = MaxHealth;
        anim = GetComponent<Animator>();
        GameObject Feuerwerfer = GameObject.Find("Feuerwerfer");
        FlamethrowerDamage= Feuerwerfer.GetComponent<Flamethrower>().damage;
        SetHealthText();
    }
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire")) {
            CurHealth = CurHealth - FlamethrowerDamage;
        }
       // anim.Play("Hurt");
        Debug.Log(CurHealth);
        if (CurHealth == 0)
        {
            MaxLives = MaxLives - 1;
            CurHealth = MaxHealth;
            SetHealthText();
        }
        if (MaxLives == 0)
        {
            //  anim.Play("Die");
        }
        Debug.Log(MaxLives);
    }
   
    void SetHealthText()
    {
        HealthStatText.text = "Leben: " + MaxLives.ToString();
    }
}
