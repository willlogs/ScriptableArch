using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUpdateHook : ScriptableObject
{
    public SOAction Action;

    public virtual void Execute(GameObject go)
    {
        Action.Execute(go);
    }
}
