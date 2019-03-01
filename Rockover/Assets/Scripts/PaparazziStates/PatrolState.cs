﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IPaparazziState

{
    private Paparazzi paparazzi;

    public void Enter(Paparazzi paparazzi)
    {
        this.paparazzi = paparazzi;
    }

    public void Execute()
    {
        paparazzi.PaparazziMove();
        Debug.Log("Im Patrolling");
        if (paparazzi.Target != null)
        {
            paparazzi.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            paparazzi.ChangeDirection();
        }
    }
}
