using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _txt;
    private Coroutine _cor;
    private float _totalTime;

    private void OnEnable()
    {
        WordController.instance.onCurrentWord += DisplayText;
        WordController.instance.onTimer += DisplayTime;
    }
    private void DisplayText(string val)
    {
        _txt.text = val;
    }
    private void DisplayTime(bool val)
    {
        
        if(val)
        {
            if (_cor != null) StopCoroutine(_cor);
            _totalTime = WordController.instance.Cooldown;
            _cor = StartCoroutine(TimerUpdate(WordController.instance.Cooldown));
        }
        else
        {
            if (_cor != null) StopCoroutine(_cor);
        }
    }
    private IEnumerator TimerUpdate(float time)
    {
        while(_totalTime != 0)
        {
            _txt.text = $"{(int)(_totalTime)}...";
            SFXManager.instance.PlaySound("Main", "Timer");
            yield return new WaitForSeconds(time / 3);
            _totalTime--;
        }
        
    }
    private void OnDisable()
    {
        WordController.instance.onCurrentWord -= DisplayText;
        WordController.instance.onTimer -= DisplayTime;
    }
}
