using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupSecretDoor : MonoBehaviour {


    [SerializeField] TextMeshProUGUI Popup;
    [SerializeField] private Transform player;
    private BoxCollider2D Door_Collider;
    private bool switchOn;
    [SerializeField] float ShowOnDistance;

    // Use this for initialization
    void Start()
    {
        Popup.enabled = false;
        Door_Collider = GetComponent<BoxCollider2D>();
        GameObject Schalter = GameObject.FindGameObjectWithTag("Schalter");
        switchOn = Schalter.GetComponent<Switch>().SwitchIsOn;
    }

    void FixedUpdate()
    {
        ShowPopUp();
        Debug.Log(switchOn);
    }

    private void ShowPopUp()
    {
        Popup.enabled = Vector3.Distance(transform.position, player.position) < ShowOnDistance && switchOn == false ? true : false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (switchOn == true)
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
