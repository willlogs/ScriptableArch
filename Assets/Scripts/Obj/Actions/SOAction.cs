using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOAction : ScriptableObject
{
    public abstract void Execute(GameObject go);

    public virtual void Kill()
    {
        Debug.LogWarning("No kill method found");
    }
}
