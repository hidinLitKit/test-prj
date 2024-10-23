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
    public void OnMove(InputValue value)
    {
        _moveValue = value.Get<Vector2>();
    }
    void Update()
    {
        if(_canMove)
        {
            _player.transform.position += new Vector3(0f, _moveValue.y * _speed * Time.deltaTime, 0f);
        }
    }
}
