using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _hp = 3f;
    private void OnEnable()
    {
        GameEvents.onFailure += Damage;
    }
    private void OnDisable()
    {
        GameEvents.onFailure -= Damage;
    }
    private void Damage()
    {
        _hp--;
        if (_hp <= 0) Debug.Log("ÏÎÐÀÆÅÍÈÅ");
    }
}
