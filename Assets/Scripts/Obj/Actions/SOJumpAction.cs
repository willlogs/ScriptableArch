using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Actions/Jump", fileName = "JumpAction")]
public class SOJumpAction : SOPlayerPhysicsAction
{
    public float jumpPower;
    public float repelPower;
    
    public override void Execute(GameObject go)
    {
        if(CheckDependencies(go))
        {
            Vector2 vel = rb.velocity;
            if (Control.state != PlayerState.WalledLeft && Control.state != PlayerState.WalledRight && Control.grounded)
            {
                rb.velocity = new Vector2(vel.x, vel.y > jumpPower ? vel.y : jumpPower);
            }
            else
            {
                if (Control.state == PlayerState.WalledLeft)
                {
                    rb.velocity = new Vector2(repelPower, vel.y > jumpPower ? vel.y : jumpPower);
                }
                else
                {
                    if (Control.state == PlayerState.WalledRight)
                    {
                        rb.velocity = new Vector2(-repelPower, vel.y > jumpPower ? vel.y : jumpPower);
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("dependencies(rb or control) not found on " + go.name);
        }
    }
}
