using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TimeAction")]
public class SOTimeAction : SOAction
{
    public SOTimeSystem TS;
    public TimeSystemState Type;

    public override void Execute(GameObject go)
    {
        switch (Type)
        {
            case TimeSystemState.Normal:
                TS.NormalSpeed();
                break;
            case TimeSystemState.Slw1:
                TS.SlowDown1();
                break;
            case TimeSystemState.Slw2:
                TS.SlowDown2();
                break;
        }
    }
}

public enum TimeSystemState
{
    Slw1,
    Slw2,
    Normal
}
