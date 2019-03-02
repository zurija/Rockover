using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : IPaparazziState { 

    private Paparazzi Paparazzi;

    public void Enter(Paparazzi Paparazzi)
    {
        
    }

    public void Execute()
    {
        Paparazzi.PaparazziMove();
        if (Paparazzi.Target != null)
        {
            Paparazzi.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {
        
    }

public void OnTriggerEnter(Collider2D other)
{

    if (other.tag == "Edge")
    {
        Paparazzi.ChangeDirection();
    }
}
}
