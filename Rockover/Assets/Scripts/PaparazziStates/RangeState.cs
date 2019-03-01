using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeState : IPaparazziState

{
    private Paparazzi Paparazzi;

    public void Enter(Paparazzi paparazzi)
    {
        this.Paparazzi = paparazzi;
    }

    public void Execute()
    {
        if (Paparazzi.Target != null)
        {
            Paparazzi.PaparazziMove();
        } else
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
