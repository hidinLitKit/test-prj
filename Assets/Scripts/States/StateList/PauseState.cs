using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : GameState
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Time.timeScale = 0;
        InputController.instance.SetInputMap(InputController.UIMap);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        Time.timeScale = 1;
    }
}
