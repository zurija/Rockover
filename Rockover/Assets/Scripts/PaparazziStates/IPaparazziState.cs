using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPaparazziState {
    void Execute();
    void Enter(Paparazzi Paparazzi);
    void Exit();
    void OnTriggerEnter(Collider2D other);
}
