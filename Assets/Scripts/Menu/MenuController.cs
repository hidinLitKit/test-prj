using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    private void OnEnable()
    {
        _startGame.onClick.AddListener(() => SceneManager.LoadScene("Main"));
    }
    private void OnDisable()
    {
        _startGame.onClick.RemoveAllListeners();
    }

}
