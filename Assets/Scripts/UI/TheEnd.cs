using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private void OnCollisionEnter(Collision collision)
    {
        _textMeshPro.text = "The end";
    }
}
