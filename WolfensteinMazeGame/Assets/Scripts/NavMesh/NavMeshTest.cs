using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class NavMeshTest : MonoBehaviour
{
    [SerializeField] private Transform _movePosition;

    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.destination = _movePosition.position;
    }
}

