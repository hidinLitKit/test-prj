using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState : GameState
{
    protected override void OnEnable()
    {
        base.OnEnable();
        InputController.instance.SetInputMap(InputController.PlayerMap);
    }
}
