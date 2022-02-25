using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent), typeof(StateMachine))]
    public class Guard : MonoBehaviour
    {
        [SerializeField] private GuardPatrolPoint[] _guardPatrolPoints;
        
        private NavMeshAgent _navMeshAgent;
        private StateMachine _stateMachine;

        public void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _stateMachine = GetComponent<StateMachine>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public GuardPatrolPoint[] patrolPoints
        {
            get
            {
                return _guardPatrolPoints;
            }
        }
    }
}