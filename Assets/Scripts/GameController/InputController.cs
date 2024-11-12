using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class InputController : MonoBehaviour
{
    #region Singleton
    public static InputController instance => _instance;
    private static InputController _instance;
    private void Awake()
    {
        if (instance == null) _instance = this;
        else Destroy(this.gameObject);
    }
    #endregion
    [SerializeField] private PlayerInput _input;
    public const string PlayerMap = "Player";
    public const string UIMap = "UI";

    public void SetInputMap(string type)
    {
        _input.SwitchCurrentActionMap(type);
    }
}
