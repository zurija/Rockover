﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private Vector2 posA;
    private Vector2 posB;
    [SerializeField] private float movementSpeed;
    private Vector2 nextPos;
    [SerializeField] private Transform childTransform;
    [SerializeField] private Transform transformB; 
	// Use this for initialization
	void Start () {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    private void Move()
    {
        childTransform.localPosition = Vector2.MoveTowards(childTransform.localPosition, nextPos, movementSpeed*Time.deltaTime);
        if (Vector2.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }
    }
    private void ChangeDestination()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}
