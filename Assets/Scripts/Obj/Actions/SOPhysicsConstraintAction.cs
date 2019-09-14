using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/PhysicsConstraint")]
public class SOPhysicsConstraintAction : SOPhysicsAction
{
    public float fallSpeedLimit;
    public bool fallSpeedLimit_;
    
    public override void Execute(GameObject go)
    {
        if (!rb)
        {
            GetRb(go);
        }

        if (rb)
        {
            if(fallSpeedLimit_)
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -fallSpeedLimit, Mathf.Infinity));
        }
    }
}
