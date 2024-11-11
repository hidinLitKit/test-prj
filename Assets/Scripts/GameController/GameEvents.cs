using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameEvents
{
    public static event Action<float, float> onUpdatePlayer;
    public static event Action onCheckPoint;
    public static event Action onCorrect;
    public static event Action onFailure;
    public static void CheckPoint()
    {
        onCheckPoint?.Invoke();
    }
    public static void GotCorrect()
    {
        onCorrect?.Invoke();
    }
    public static void GotWrong()
    {
        onFailure?.Invoke();
    }
    public static void UpdatePlayer(float val1, float val2)
    {
        onUpdatePlayer?.Invoke(val1, val2);
    }
}
