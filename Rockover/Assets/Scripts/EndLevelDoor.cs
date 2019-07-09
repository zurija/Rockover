using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelDoor : MonoBehaviour {

    public GameObject[] Boss;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    void FixedUpdate () {
        Boss = GameObject.FindGameObjectsWithTag("Boss");
        if (Boss.Length == 0)
        {
            gameObject.SetActive(false);
        }
	}
}
