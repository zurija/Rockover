using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerPoint : MonoBehaviour {

    [SerializeField] private Slider mySlider;
    [SerializeField] private GameObject Boss;

	// Use this for initialization
	void Start () {
        mySlider.gameObject.SetActive(false);
        Boss.gameObject.SetActive(false);
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mySlider.gameObject.SetActive(true);
        Boss.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
