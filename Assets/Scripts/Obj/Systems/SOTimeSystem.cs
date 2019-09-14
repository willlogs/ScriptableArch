using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/TimeSystem")]
public class SOTimeSystem : ScriptableObject
{
    public float Scale1, Scale2;
    public TimeSystemState state = TimeSystemState.Normal;

    private float mainFixedDelta;

    private void OnEnable()
    {
        mainFixedDelta = Time.fixedDeltaTime;
    }

    public void SlowDown1()
    {
        if(state != TimeSystemState.Slw1)
        {
            Time.timeScale = Scale1;
            Time.fixedDeltaTime = Scale1 * 2 / 100;
            state = TimeSystemState.Slw1;
        }
        else
        {
            NormalSpeed();
        }
    }

    public void SlowDown2()
    {
        if(state != TimeSystemState.Slw2)
        {
            Time.timeScale = Scale2;
            Time.fixedDeltaTime = Scale2 * 2 / 100;
            state = TimeSystemState.Slw2;
        }

        else
        {
            NormalSpeed();
        }
    }

    public void NormalSpeed()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = mainFixedDelta;
        state = TimeSystemState.Normal;
    }
}
