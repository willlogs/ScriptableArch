using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOPlayerPhysicsAction : SOPhysicsAction
{
    protected PlayerControl Control;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        Control = null;
    }

    protected void GetControl(GameObject go)
    {
        Control = go.GetComponent<PlayerControl>();
    }

    protected bool CheckDependencies(GameObject go)
    {
        if (!rb)
        {
            GetRb(go);
        }
        if (!Control)
        {
            GetControl(go);
        }

        return rb && Control;
    }
}
