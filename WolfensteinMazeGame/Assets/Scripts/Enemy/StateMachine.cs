using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Enemy
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State _StartingState;
        
        
        private State _currentState;

        public void Awake()
        {
            _currentState = null;
        }

        public void Start()
        {
            if (_StartingState != null)
            {
                EnterState(_StartingState);
            }
        }

        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.UpdateState();
            }
        }

        #region State Management

        public void EnterState(State nextState)
        {
            if (nextState == null)
            {
                return;
            }

            _currentState = nextState;
            
        }

        #endregion
        
    }
}