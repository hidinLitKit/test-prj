using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _hp = 3f;
    private float _score = 0f;
    
    private void OnEnable()
    {
        GameEvents.onFailure += Damage;
        GameEvents.onCorrect += Score;
    }
    private void OnDisable()
    {
        GameEvents.onFailure -= Damage;
        GameEvents.onCorrect += Score;
    }
    private void Damage()
    {
        _hp--;
        if (_hp <= 0) _hp = 0;
        Debug.Log("ÏÎÐÀÆÅÍÈÅ");
        UpdatePlayer();
    }
    private void Score()
    {
        _score++;
        UpdatePlayer();
    }
    private void UpdatePlayer()
    {
        GameEvents.UpdatePlayer(_hp, _score);
    }
}
