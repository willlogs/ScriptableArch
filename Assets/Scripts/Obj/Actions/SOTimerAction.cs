using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TimerUpdateAction")]
public class SOTimerAction : SOUpdateHook
{
    private List<TimerHook> timerHooks = new List<TimerHook>();

    public bool Testing = false;
    public float Time_ = 0;

    private void OnEnable()
    {
        Time_ = 0;
    }

    public void RegisterHook(TimerHook hook)
    {
        if (!timerHooks.Contains(hook))
        {
            timerHooks.Add(hook);
        }
    }

    public void UnregisterHook(TimerHook hook)
    {
        if (timerHooks.Contains(hook))
        {
            timerHooks.Remove(hook);
        }
    }

    public override void Execute(GameObject go)
    {
        if(timerHooks.Count > 0)
        {
            for (int i = timerHooks.Count - 1; i >= 0; i--)
            {
                timerHooks[i].Tick(Time.deltaTime);
            }
        }

        if (Testing)
        {
            Time_ += Time.deltaTime;
            Debug.Log(Time_);
        }
    }
}
