using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private bool _actionPerformed = false;
    
    [SerializeField] private Vector3 _goalPos;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private float _openingSpeed = 0.5f;
    
    private float _current, _target;

    private void Awake()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        if (_actionPerformed) _target = _target == 0 ? 1 : 0; //if (door got hit by player ray, move to target -> wait [time] -> move back
        MoveToTarget();

        if (_target >= 0 || _target <= 1) _actionPerformed = false;
    }

    private void MoveToTarget()
    {
        _current = Mathf.MoveTowards(_current, _target, _openingSpeed * Time.deltaTime);

        transform.position = Vector3.Lerp(_startPos, _startPos + _goalPos, _current);
    }
}
