using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : GameState
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Time.timeScale = 0.1f;
        InputController.instance.SetInputMap(InputController.UIMap);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        Time.timeScale = 1;
    }
}
