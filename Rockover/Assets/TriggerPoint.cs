using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerPoint : MonoBehaviour {

    [SerializeField] private Slider mySlider;

	// Use this for initialization
	void Start () {
        mySlider.gameObject.SetActive(false);
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mySlider.gameObject.SetActive(true);
    }
}
