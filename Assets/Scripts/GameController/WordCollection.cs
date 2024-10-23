using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCollection : MonoBehaviour
{
    public List<GameObject> wordPlaceVariations;

    private List<WordObject> words = new List<WordObject>();
    private void Awake()
    {
        PlacementGen();
    }
    private void Start()
    {
        ScrambleWords();
    }
    private void OnEnable()
    {
        WordController.instance.onTimer += DisplayObject;
    }
    private void OnDisable()
    {
        WordController.instance.onTimer -= DisplayObject;
    }
    private void DisplayObject(bool val)
    {
        foreach (WordObject word in words) word.SetVisibility(val);
    }
    private void PlacementGen()
    {
        foreach (GameObject obj in wordPlaceVariations)
            obj.SetActive(false);

        GameObject wrds = wordPlaceVariations[Random.Range(0, wordPlaceVariations.Count - 1)];
        wrds.SetActive(true);

        words = new List<WordObject>(wrds.GetComponentsInChildren<WordObject>());
    }
    private void ScrambleWords()
    {
        foreach (WordObject word in words)
        {
            word.SetWord(WordController.instance.RandomWord);
        }
        words[Random.Range(0, words.Count)].SetWord(WordController.instance.CurrentWord);
    }
}

[System.Serializable]
public class Words
{
    public List<WordObject> words = new List<WordObject>();
}
