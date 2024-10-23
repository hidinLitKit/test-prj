using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    #region Singleton
    public static WordController instance => _instance;
    private static WordController _instance;
    private void Awake()
    {
        if (instance == null) _instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public WordData CurrentWord => _currentWord;
    public WordData RandomWord => _words.RandomWord();
    public event System.Action<bool> onTimer;
    public event System.Action<string> onCurrentWord;
    
    [SerializeField] private WordDatabase _words;
    [SerializeField] private float _coolDown = 3f;

    private WordData _currentWord;
    private void OnEnable()
    {
        _currentWord = _words.RandomWord();
        GameEvents.onCorrect += CorrectSequence;
        GameEvents.onFailure += WrongSequence;
    }
    private void Start()
    {
        onCurrentWord?.Invoke(_currentWord._englishWord);
    }
    private void OnDisable()
    {
        GameEvents.onCorrect -= CorrectSequence;
        GameEvents.onFailure -= WrongSequence;
    }
    private void CorrectSequence()
    {
        StartCoroutine(Timer());
    }
    private void WrongSequence()
    {

    }
    private IEnumerator Timer()
    {
        onTimer?.Invoke(true);
        yield return new WaitForSeconds(_coolDown);
        _currentWord = _words.RandomWord();
        onCurrentWord?.Invoke(_currentWord._englishWord);
        onTimer?.Invoke(false);
    }


}
