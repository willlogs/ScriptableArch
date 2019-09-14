using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOPhysicsAction : SOAction
{
    protected Rigidbody2D rb;

    protected virtual void OnEnable()
    {
        rb = null;
    }

    protected void GetRb(GameObject go)
    {
        rb = go.GetComponent<Rigidbody2D>();
    }
}
