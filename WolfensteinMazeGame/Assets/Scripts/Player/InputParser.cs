using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputParser : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.MovementActions _playerControlsActions;

    [SerializeField] private CharacterControllerMove _charConMove;
    [SerializeField] private Shoot _shoot;
    [SerializeField] private CameraRotate _camRot;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerControlsActions = _playerInput.Movement;

        _playerControlsActions.Shoot.performed += _shoot.PlayerShoot;
        _playerControlsActions.Action.performed += _charConMove.Action;
        
        _playerControlsActions.Enable();
    }

    private void FixedUpdate()
    {
        _camRot.PlayerLookAt(_playerControlsActions.MousePosition.ReadValue<Vector2>());
        _charConMove.PlayerMove(_playerControlsActions.Move.ReadValue<Vector2>());
    }
}
