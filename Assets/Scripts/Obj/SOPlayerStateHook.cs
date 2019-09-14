using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hooks/PlayerStateHook")]
public class SOPlayerStateHook : SOPlayerUpdateHook
{
    public List<PlayerState> states;

    public override void Execute(GameObject go)
    {
        if (CheckDependencies(go))
        {
            foreach (PlayerState ps in states)
            {
                if (Control.state == ps)
                {
                    base.Execute(go);
                    break;
                }
            }
        }
    }
}
