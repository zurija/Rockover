using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelDoor : MonoBehaviour {

    private GameObject Boss;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    void FixedUpdate () {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        checkBoss();
	}

    public void checkBoss()
    {
        if (Boss != null) {
            gameObject.SetActive(true);
        } else
        {
        gameObject.SetActive(false);
        }
    }
}
