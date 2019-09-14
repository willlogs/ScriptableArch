using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSensor : MonoBehaviour
{
    private Collider2D _collider;
    private int collidersCount = 0;

    public bool Collided = false;
        
    void Start()
    {
            if(!GetComponent<Collider2D>())
                Debug.LogWarning("Collider Sensor: no collider on " + name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collidersCount++;
        Collided = collidersCount > 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        collidersCount--;
        Collided = collidersCount > 0;
    }
}