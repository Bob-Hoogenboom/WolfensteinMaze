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
    [SerializeField] private CharacterController _charController;
    public Vector3 velocity; //public so 'GroundChecker' can acces

    
    private void Update()
    {
        velocity.y += _gravity * Time.deltaTime;
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
}