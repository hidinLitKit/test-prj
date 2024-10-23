using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _txt;
    private void OnEnable()
    {
        WordController.instance.onCurrentWord += DisplayText;
    }
    private void DisplayText(string val)
    {
        _txt.text = val;
    }
    private void OnDisable()
    {
        WordController.instance.onCurrentWord -= DisplayText;
    }
}
