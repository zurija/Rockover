using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public bool SwitchIsOn;
    [SerializeField] GameObject SwitchOn;
    [SerializeField] GameObject SwitchOff;

	// Use this for initialization
	void Start () {
        SwitchIsOn = false; 
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOff.GetComponent<SpriteRenderer>().sprite;
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOn.GetComponent<SpriteRenderer>().sprite;
        SwitchIsOn = true;
    }

}
