using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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
    [ContextMenu("Export to CSV")]
    public void ExportToCSV()
    {
        string filePath = Application.dataPath + "/WordDatabase.csv";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Index,EnglishWord,RussianWord");
            foreach (var word in database)
            {
                writer.WriteLine($"{word._index},{word._englishWord},{word._russianWord}");
            }
        }
        Debug.Log("Exported to CSV at " + filePath);
    }

    [ContextMenu("Import from CSV")]
    public void ImportFromCSV()
    {
        string filePath = Application.dataPath + "/WordDatabase.csv";
        if (!File.Exists(filePath))
        {
            Debug.LogError("CSV file not found at " + filePath);
            return;
        }

        database.Clear();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string headerLine = reader.ReadLine(); // Skip header
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                if (values.Length == 3)
                {
                    WordData wordData = new WordData
                    {
                        _index = values[0],
                        _englishWord = values[1],
                        _russianWord = values[2]
                    };
                    database.Add(wordData);
                }
            }
        }
        Debug.Log("Imported from CSV at " + filePath);
    }
}

[System.Serializable]
public class WordData
{
    public string _englishWord;
    public string _russianWord;
    public string _index;
}

