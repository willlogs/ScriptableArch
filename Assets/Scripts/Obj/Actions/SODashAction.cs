using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Dash")]
public class SODashAction : SOPhysicsAction
{
    public float DashSpeed = 30, DashDuration = 0.2f;
    public SOTimerAction Timer;
    public SOPlayerControl A, D;

    private Vector2 beforeDash;
    private GameObject go;
    private TimerHook hook;
    
    public void StopDash(object sender, TimerEventArgs e)
    {
        if(rb)
        {
            rb.velocity = beforeDash;
        }
    }
    
    public override void Execute(GameObject go)
    {
        if (!rb)
        {
            GetRb(go);
        }
        
        beforeDash = new Vector2(rb.velocity.x, rb.velocity.y);
        if(D.isOnHold)
        {
            rb.velocity = new Vector2(DashSpeed, rb.velocity.y);
        }
        else
        {
            if(A.isOnHold)
                rb.velocity = new Vector2(-DashSpeed, rb.velocity.y);
        }
        
        hook = new TimerHook(DashDuration, Timer);
        hook.TimerEvent += StopDash;
    }

}
