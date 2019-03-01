using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaparazziSight : MonoBehaviour {
    [SerializeField] private Paparazzi Paparazzi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Paparazzi.Target = other.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Paparazzi.Target = null;
        }
    }
}
