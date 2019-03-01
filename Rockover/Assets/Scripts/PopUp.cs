using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUp : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Popup;
    [SerializeField] Transform player;
    private BoxCollider2D Door_Collider;
    private bool badge;
    [SerializeField] float ShowOnDistance;

    // Use this for initialization
    void Start()
    {
        Popup.enabled = false;
        Door_Collider = GetComponent<BoxCollider2D>();
        GameObject Player = GameObject.Find("Player");
        badge = Player.GetComponent<Player_Controller>().hasBadge;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowPopUp();
    }

    private void ShowPopUp()
    {
        if (Vector3.Distance(transform.position, player.position) < ShowOnDistance && badge == false)
        {
            Popup.enabled = true;
        }
        else
        {
            Popup.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (badge == true)
        {
            Door_Collider.enabled = false;

        }
        else
        {
            Door_Collider.enabled = true;
        }
    }
}

