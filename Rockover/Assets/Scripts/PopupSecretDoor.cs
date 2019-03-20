using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupSecretDoor : MonoBehaviour {


    [SerializeField] TextMeshProUGUI Popup;
    [SerializeField] private Transform player;
    private BoxCollider2D Door_Collider;
    [SerializeField] float ShowOnDistance;
    private GameObject Schalter; 

    // Use this for initialization
    void Start()
    {
        Popup.enabled = false;
        Door_Collider = GetComponent<BoxCollider2D>();
        Schalter = GameObject.FindGameObjectWithTag("Schalter");
    }

    void FixedUpdate()
    {
        ShowPopUp();
    }

    private void ShowPopUp()
    {
        Popup.enabled = Vector2.Distance(transform.position, player.position) < ShowOnDistance && Schalter.GetComponent<Switch>().SwitchIsOn == false ? true : false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Schalter.GetComponent<Switch>().SwitchIsOn == true)
        {
            Door_Collider.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            Door_Collider.enabled = true;
        }
    }
}
