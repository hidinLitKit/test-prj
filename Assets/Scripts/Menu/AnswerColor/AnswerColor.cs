using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerColor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        GameEvents.onCorrect += CorrectColor;
        GameEvents.onFailure += WrongColor;
    }
    private void OnDestroy()
    {
        GameEvents.onCorrect -= CorrectColor;
        GameEvents.onFailure -= WrongColor;
    }
    void WrongColor()
    {
        _animator.SetTrigger("Wrong");
    }
    void CorrectColor()
    {
        _animator.SetTrigger("Correct");
    }
}
