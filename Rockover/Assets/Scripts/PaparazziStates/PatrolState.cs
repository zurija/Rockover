using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IPaparazziState

{
    private Paparazzi paparazzi;

    public void Enter(Paparazzi paparazzi)
    {
        this.paparazzi = paparazzi;
        paparazzi.Target = null;
    }

    public void Execute()
    {
        paparazzi.PaparazziMove();
        if (paparazzi.Target != null)
        {
            paparazzi.ChangeState(new RangeState());
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
