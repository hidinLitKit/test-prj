using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMenuControls : MonoBehaviour
{
    #region Death
    [SerializeField] private Button _againButton;
    [SerializeField] private Button _menuButton1;
    #endregion
    #region PauseMenu
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _menuButton2;
    #endregion
    private const string _mainScene = "Main";
    private const string _menuScene = "Menu";
    private void OnEnable()
    {
        GameEvents.onDeath += () => States.instance.Push<DeathState>();

        _againButton.onClick.AddListener( () => SceneManager.LoadScene(_mainScene));
        _menuButton1.onClick.AddListener(() => SceneManager.LoadScene(_menuScene));
        _menuButton2.onClick.AddListener(() => SceneManager.LoadScene(_menuScene));
        _continueButton.onClick.AddListener(() => States.instance.Push<MainState>());

    }
    private void OnDisable()
    {
        GameEvents.onDeath -= () => States.instance.Push<DeathState>();

        _againButton.onClick.RemoveListener(() => SceneManager.LoadScene(_mainScene));
        _menuButton1.onClick.RemoveListener(() => SceneManager.LoadScene(_menuScene));
        _menuButton2.onClick.RemoveListener(() => SceneManager.LoadScene(_menuScene));
        _continueButton.onClick.RemoveListener(() => States.instance.Push<MainState>());
    }
}
