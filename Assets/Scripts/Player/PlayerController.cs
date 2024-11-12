using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 1f;
    private bool _canMove = true;
    private Vector2 _moveValue;
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveValue = context.ReadValue<Vector2>();
    }
    public void OnExit(InputAction.CallbackContext context)
    {
        if (context.performed)
            States.instance.Push<PauseState>();
    }
    void Update()
    {
        if(_canMove)
        {
            _player.transform.position += new Vector3(0f, _moveValue.y * _speed * Time.deltaTime, 0f);
        }
    }
}
