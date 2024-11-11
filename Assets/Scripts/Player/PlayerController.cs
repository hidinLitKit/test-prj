using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _rotationLerp = 1f;
    [SerializeField] private GameObject _rotationPoint;
    [SerializeField] private CharacterController _characterController;
    private Vector2 _move;
    private Vector2 _look;
    private float _jump;
    private Quaternion _nextRotation;

    private Vector3 vertical = Vector3.zero;
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        _look= value.Get<Vector2>();
    }
    public void OnJump(InputValue value)
    {
        //JUMP TODO не работает...
        //_jump = value.Get<float>();
    }
    
    public void OnInteract(InputValue value)
    {
        Debug.Log("Типа взаимодействие");
    }
    public void Update()
    {
        VerticalMovement();
        Movement();
        RotateCamera();
    }
    private void RotateCamera()
    {
        _nextRotation = _rotationPoint.transform.rotation;
        _nextRotation *= Quaternion.AngleAxis(_look.x, Vector3.up);
        _nextRotation *= Quaternion.AngleAxis(_look.y, Vector3.right);
        _rotationPoint.transform.rotation = Quaternion.Lerp( _rotationPoint.transform.rotation,_nextRotation, _rotationLerp);
        
        var angles = _rotationPoint.transform.localEulerAngles;
        angles.z = 0;

        var angle = _rotationPoint.transform.localEulerAngles.x;

        _rotationPoint.transform.localEulerAngles = angles;
    }
    private void VerticalMovement()
    {   
        if(_jump == 1f)
        {
            vertical.y += Mathf.Sqrt( (-2f) * _jumpHeight* Physics.gravity.y);
        }
        vertical.y += Physics.gravity.y * Time.deltaTime;
        _characterController.Move(vertical * Time.deltaTime);
    }
    private void Movement()
    {
        Vector3 position = (_characterController.transform.forward * _move.y *_moveSpeed) + (_characterController.transform.right * _move.x *_moveSpeed);
        Debug.Log(position);
        _characterController.Move(position * Time.deltaTime);

    }
}
