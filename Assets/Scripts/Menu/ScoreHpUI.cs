using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hp;
    [SerializeField] private TextMeshProUGUI _score;
    private void OnEnable()
    {
        GameEvents.onUpdatePlayer += UpdateValues;
    }
    private void OnDisable()
    {
        GameEvents.onUpdatePlayer -= UpdateValues;
    }
    private void UpdateValues(float val1, float val2)
    {
        _hp.text = $"x{val1}";
        _score.text = $"{val2}";
    }
}
