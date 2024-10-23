using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordDatabase")]
public class WordDatabase : ScriptableObject
{
    [SerializeField] private List<WordData> database;
    public WordData RandomWord()
    {
        return database[Random.Range(0, database.Count - 1)];
    }
    public WordData GetCurrent(WordData _previous)
    {
        return database[Random.Range(0, database.Count - 1)];
    }
}

[System.Serializable]
public class WordData
{
    public string _englishWord;
    public string _russianWord;
    public string _index;
}

