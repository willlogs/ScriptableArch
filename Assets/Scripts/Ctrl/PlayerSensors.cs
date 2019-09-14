using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensors : MonoBehaviour
{
    public ColliderSensor Left, Right, Bottom;
    public bool IsLeft, IsRight, IsBottom;

    private void Update()
    {
        IsLeft = Left.Collided;
        IsRight = Right.Collided;
        IsBottom = Bottom.Collided;
    }
}
