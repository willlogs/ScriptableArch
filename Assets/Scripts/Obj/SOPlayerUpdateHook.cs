using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOPlayerUpdateHook : SOUpdateHook
{
    
    protected PlayerControl Control;
    
    protected void OnEnable()
    {
        Control = null;
    }

    protected void GetControl(GameObject go)
    {
        Control = go.GetComponent<PlayerControl>();
    }

    protected bool CheckDependencies(GameObject go)
    {
        if (!Control)
        {
            GetControl(go);
        }

        return Control;
    }
}
