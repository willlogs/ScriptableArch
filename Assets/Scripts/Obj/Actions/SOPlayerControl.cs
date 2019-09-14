using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerCtrl", menuName = "Actions/Ctrl")]
public class SOPlayerControl : SOUpdateHook
{
    public KeyCode key;
    public bool oneTap = false;
    public bool killOnUp;
    public bool isOnHold;
    public float restTime = 0;
    public SOTimerAction Timer;

    private bool resting = false;
    private TimerHook hook;
    
    private void StopRest(object sender, TimerEventArgs e)
    {
        resting = false;
    }

    private void StartRest()
    {
        if(restTime > 0)
        {
            resting = true;
            hook = new TimerHook(restTime, Timer);
            hook.TimerEvent += StopRest;
        }
    }

    public override void Execute(GameObject go)
    {
        isOnHold = Input.GetKey(key);
        
        if(!resting)
        {
            if (oneTap)
            {
                if (Input.GetKeyDown(key))
                {
                    Action.Execute(go);
                    StartRest();
                }
            }

            else
            {
                if (Input.GetKey(key))
                {
                    Action.Execute(go);
                    StartRest();
                }
            }
        }

        if (killOnUp && Input.GetKeyUp(key))
        {
            Action.Kill();
        }
    }
}
