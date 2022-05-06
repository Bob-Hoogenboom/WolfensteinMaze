using System;
using UnityEngine;
using Utility;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    //PlayerInput Variables
    private PlayerInput _playerInput;
    private Vector2 _moveDirection;
    private InputAction _move;
    private InputAction _fire;

    private CharacterController _charCon;
    [SerializeField] private float _walkSpeed;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _move = _playerInput.Movement.Move;
        _move.Enable();

        _fire = _playerInput.Movement.Fire;
        _fire.Enable();
        _fire.performed += Fire;
    }
    
    private void OnDisable()
    {
        _move.Disable();
        _fire.Disable();
    }

    private void Start()
    {
        _charCon = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveDirection = _move.ReadValue<Vector2>();
        
        if (Vector.IsLengthZero(_moveDirection)) return;
        // Debug.Log("Walk");
    
        float x = _moveDirection.x;
        float z = _moveDirection.y;

        Vector3 move = transform.right * x + transform.forward * z;
        _charCon.Move(move * _walkSpeed * Time.deltaTime);
        
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Pew Pew");
    }
}
