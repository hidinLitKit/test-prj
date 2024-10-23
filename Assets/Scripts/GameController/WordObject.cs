using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordObject : MonoBehaviour
{
    [SerializeField] private GameObject _active;
    [SerializeField] private TextMeshPro _displayTxt;
    private WordData _word;
    private bool _visible = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _visible)
        {
            if (WordController.instance.CurrentWord == _word)
                GameEvents.GotCorrect();
            else
            {
                GameEvents.GotWrong();
                SetVisibility(false);
            }
        }
    }
    public void SetWord(WordData word)
    {
        _word = word;
        _displayTxt.text = word._russianWord;
    }
    public void SetVisibility(bool val)
    {
        _active.SetActive(val);
        _visible = val;
    }
}
