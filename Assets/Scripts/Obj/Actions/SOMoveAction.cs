using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "MoveAction", menuName = "Actions/Move")]
public class SOMoveAction : SOPlayerPhysicsAction
{
    public Vector2 MoveVector;
    public float effectIn = 0.1f;

    private Tweener _currentTween;

    public override void Execute(GameObject go)
    {
        if(CheckDependencies(go))
        {
            if (MoveVector.y == 0.00f)
            {
                if((MoveVector.x < 0 && Control.state != PlayerState.WalledLeft) || (MoveVector.x > 0 && Control.state != PlayerState.WalledRight))
                {
                    _currentTween?.Kill();

                    _currentTween = DOTween.To(() => rb.velocity, (x) => rb.velocity = x,
                        new Vector2(MoveVector.x, rb.velocity.y), effectIn);
                }
            }
            else
            {
                rb.velocity = MoveVector;
            }

            if (Control.state == PlayerState.WalledLeft || Control.state == PlayerState.WalledRight)
            {
                Kill();
            }
        }
    }

    public override void Kill()
    {
        _currentTween.Kill();
        _currentTween = null;
    }
}
