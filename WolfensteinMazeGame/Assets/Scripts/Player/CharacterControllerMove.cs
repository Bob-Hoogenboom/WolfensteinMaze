using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

public class CharacterControllerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _gravity = -9.81f;
    
    
    [Space]
    [SerializeField] private float _reach;
    [SerializeField] private bool _colliderHit;
    [SerializeField] private Transform _actionOBJ;
    [SerializeField] private DoorScript _doorScript;
    [SerializeField] private Vector3 _boxSize;
    [SerializeField] private LayerMask _door;
    [SerializeField] private RaycastHit _hit;

    [Space]
    [SerializeField] private CharacterController _charController;
    public Vector3 velocity; //public so 'GroundChecker' can acces

    private void Update()
    {
        velocity.y += _gravity * Time.deltaTime;
    }

    public void Action(InputAction.CallbackContext context)
    {
        _colliderHit = Physics.BoxCast(_actionOBJ.position, _boxSize,_actionOBJ.transform.forward, out _hit, _actionOBJ.rotation,_reach,_door);
        
        if (_colliderHit)
        {
            _doorScript = _hit.transform.GetComponentInParent<DoorScript>();
            Debug.Log(_hit.transform);
            _doorScript.doorOpen = true;
        }
        Debug.Log("Action");
    }
    
    
    public void PlayerMove(Vector2 Dir)
    {
        if (Vector.IsLengthZero(Dir)) return;
        Debug.Log("Walk");
    
        float x = Dir.x;
        float z = Dir.y;

        Vector3 move = transform.right * x + transform.forward * z;
        _charController.Move(move * _speed * Time.deltaTime);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Check if there has been a hit yet
        if (_colliderHit)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(_actionOBJ.position, _actionOBJ.transform.forward * _hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(_actionOBJ.position + _actionOBJ.transform.forward * _hit.distance, _boxSize);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(_actionOBJ.position, _actionOBJ.transform.forward * _reach);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(_actionOBJ.position + _actionOBJ.transform.forward * _reach, _boxSize);
        }
    }
}