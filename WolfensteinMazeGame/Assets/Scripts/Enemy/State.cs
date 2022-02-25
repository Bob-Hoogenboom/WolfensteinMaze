using UnityEngine;
using UnityEngine.AI;

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

        protected NavMeshAgent _navMeshAgent;
        protected Guard _guard;
        
        public ExecutionState ExecutionState { get; protected set; }
        public bool EnteredState { get; protected set; }

        
        public virtual void OnEnable()
        {
            ExecutionState = ExecutionState.None;
        }

        public virtual bool EnterState() //inheriting classes can override this bool because its 'virtual'
        {
            bool successNavMesh = true;
            bool successGuard = true;
            
            ExecutionState = ExecutionState.Active;
            
            //does the NavMeshAGent exist?
            successNavMesh = (_navMeshAgent != null);
            
            //does the executing agent exist?
            successGuard = (_guard != null); 
            return successNavMesh & successGuard;
        }

        public abstract void UpdateState(); //with 'abstract' you declare a method but you don't 'have' to write to it

        
        public virtual bool ExitState()
        {
            ExecutionState = ExecutionState.Completed;
            return true;
        }

        public virtual void SetNavMeshAgent(NavMeshAgent navMeshAgent)
        {
            if (navMeshAgent != null)
            {
                _navMeshAgent = navMeshAgent;
            }
        }

        public virtual void SetExecutingGuard(Guard guard)
        {
            if (guard != null)
            {
                _guard = guard;
            }
        }
        
    }
}
