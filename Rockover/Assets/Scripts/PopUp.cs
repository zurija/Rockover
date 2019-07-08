using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUp : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI Popup;
    [SerializeField] private Transform player;
    public GameObject Player; 
    private bool badge;
    [SerializeField] float ShowOnDistance;

    // Use this for initialization
    void Start()
    {
        Popup.enabled = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowPopUp();
        badge = Player.GetComponent<Player_Controller>().hasBadge;
    }

    private void ShowPopUp()
    {
        Popup.enabled = Vector2.Distance(transform.position, player.position) < ShowOnDistance && badge == false ? true : false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (badge == true)
        {
          
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}

