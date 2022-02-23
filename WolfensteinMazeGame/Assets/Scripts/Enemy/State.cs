using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    
    public enum ExecutionState
    {
        None,
        Active,
        Completed,
        Terminated,
    };
    public abstract class State : ScriptableObject
    {
        public ExecutionState ExecutionState { get; protected set; }

        
        public virtual void OnEnable()
        {
            ExecutionState = ExecutionState.None;
        }

        public virtual bool EnterState() //inheriting classes can override this bool because its 'virtual'
        {
            ExecutionState = ExecutionState.Active;
            return true;
        }

        public abstract void UpdateState(); //with 'abstract' you declare a method but you don't 'have' to write to it

        
        public virtual bool ExitState()
        {
            ExecutionState = ExecutionState.Completed;
            return true;
        }
        
    }
}
