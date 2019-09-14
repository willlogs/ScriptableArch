using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerEventArgs
{
    public TimerEventArgs()
    {
        
    }
}

public class TimerHook
{
    private float time_ = 0, limit = 0;
    
    public delegate void TimerCallBackEH(TimerHook sender, TimerEventArgs e);

    public event TimerCallBackEH TimerEvent;
    public SOTimerAction Timer;
    
    public TimerHook(float limit_, SOTimerAction Timer_)
    {
        limit = limit_;
        Timer = Timer_;
        Timer.RegisterHook(this);
    }

    public void Tick(float deltaTime)
    {
        time_ += deltaTime;
        if(time_ >= limit) RaiseTimerEvent();
    }

    protected virtual void RaiseTimerEvent()
    {
        TimerEvent?.Invoke(this, new TimerEventArgs());
        Timer.UnregisterHook(this);
    }
}
