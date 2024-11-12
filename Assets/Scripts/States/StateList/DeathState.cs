using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : GameState
{
    protected override void OnEnable()
    {
        base.OnEnable();
        InputController.instance.SetInputMap(InputController.UIMap);
    }
}
