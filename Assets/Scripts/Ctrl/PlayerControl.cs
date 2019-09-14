using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControl : MonoBehaviour
{
    public List<SOUpdateHook> hooks = new List<SOUpdateHook>();
    public PlayerSensors sensors;
    public PlayerState state = PlayerState.Idle;
    public bool grounded = false, running = false, sitting = false, dashing = false, lookingRight = true;

    private void Update()
    {
        for (int i = hooks.Count - 1; i >= 0; i--)
        {
            hooks[i].Execute(gameObject);
        }
        
        SetState();
    }

    private void SetState()
    {
        // right sensor has priority
        grounded = sensors.IsBottom;

        if (sensors.IsRight)
        {
            state = PlayerState.WalledRight;
        }
        else
        {
            if (sensors.IsLeft)
            {
                state = PlayerState.WalledLeft;
            }
            else
            {
                if (dashing)
                {
                    state = PlayerState.Dashing;
                }
                else
                {
                    if (sitting)
                    {
                        state = PlayerState.Sitting;
                    }
                    else
                    {
                        state = grounded ? PlayerState.Idle : PlayerState.Falling;
                    }
                }
            }
        }
    }
}

public enum PlayerState
{
    Idle,
    Walking,
    Running,
    Sitting,
    Dashing,
    WalledRight,
    WalledLeft,
    Falling
}