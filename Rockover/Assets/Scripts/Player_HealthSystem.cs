using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_HealthSystem : MonoBehaviour
{
    private int CurHealth;
    [SerializeField] private int MaxHealth;
    private Animator anim;
    [SerializeField] public int MaxLives;
    private int CurLives;
    private int FlamethrowerDamage;
    [SerializeField] TextMeshProUGUI HealthStatText;
    [SerializeField] Image damageImage; 
    [SerializeField] private float flashSpeed = 5f;
    [SerializeField] private Color flashColor = new Color(1f, 0f, 0f);
    bool damaged; 




    // Use this for initialization
    void Start()
    {
        CurHealth = MaxHealth;
        CurLives = MaxLives;
        anim = GetComponent<Animator>();
        GameObject Feuerwerfer = GameObject.Find("Feuerwerfer");
        FlamethrowerDamage = Feuerwerfer.GetComponent<Flamethrower>().damage;
        SetHealthText();
    }
    private void FixedUpdate()
    {
        
        playerHealthStats(); 

        if (damaged)
        {
            SoundManagerScript.PlaySound("PlayerHit");
            damageImage.color = flashColor; 
        } else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag){
            case ("Fire"):
                damaged = true;
                CurHealth = CurHealth - FlamethrowerDamage;
                break;
        }
    }


    void SetHealthText()
    {
        HealthStatText.text = "Leben: " + CurLives.ToString();
    }

    void playerHealthStats()
    {
        if (CurHealth <= 0)
        {
            CurLives = CurLives - 1;
            CurHealth = MaxHealth;
            SetHealthText();
        }
        Debug.Log(CurHealth);
        Debug.Log(CurLives);

        if (CurLives == 0)
        {
            SoundManagerScript.PlaySound("GameOver"); 
            SceneManager.LoadScene("GameOver");
        }
    }

}
