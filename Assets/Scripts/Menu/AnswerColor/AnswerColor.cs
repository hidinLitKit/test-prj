using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerColor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private void OnEnable()
    {
        GameEvents.onCorrect += () => _animator.SetTrigger("Correct");
        GameEvents.onFailure += () => _animator.SetTrigger("Wrong");
    }
    private void OnDisable()
    {
        GameEvents.onCorrect -= () => _animator.SetTrigger("Correct");
        GameEvents.onFailure -= () => _animator.SetTrigger("Wrong");
    }
}
