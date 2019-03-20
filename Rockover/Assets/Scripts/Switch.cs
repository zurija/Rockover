using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Switch : MonoBehaviour {

    public bool SwitchIsOn;
    [SerializeField] GameObject SwitchOn;
    [SerializeField] GameObject SwitchOff;
    [SerializeField] TextMeshProUGUI Hint; 

	// Use this for initialization
	void Start () {
        Hint.enabled = false;
        SwitchIsOn = false; 
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOff.GetComponent<SpriteRenderer>().sprite;
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOn.GetComponent<SpriteRenderer>().sprite;
        SwitchIsOn = true;
        Hint.enabled = true;
        Invoke("HideHint",3f);
    }
    void HideHint()
    {
        Hint.enabled = false;
    }
}
