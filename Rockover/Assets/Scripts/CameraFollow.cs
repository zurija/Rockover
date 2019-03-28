using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 Velocity;

    [SerializeField] public float smoothTimeY;
    [SerializeField] public float smoothTimeX; 

    [SerializeField] public GameObject Player; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref Velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref Velocity.y, smoothTimeX);

        transform.position = new Vector3(posX, posY, transform.position.z);

        
    }
		
}
