using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName="Idle", menuName="Unity-FSM/States/Patrol", order =2)]
    public class Patrol : State
    {
        private GuardPatrolPoint[] _patrolPoints;
        private int _patrolPointIndex;


        public override void OnEnable()
        {
            base.OnEnable();
            _patrolPointIndex = -1;
        }

        public override bool EnterState()
        {
            EnteredState = false;
            if (base.EnterState())
            {
                //grab and store the patrol poits.
                _patrolPoints = _guard.patrolPoints;

                if (_patrolPoints == null || _patrolPoints.Length == 0)
                {
                    Debug.Log("patrolState: Failed to grab patrol points from Guard");
                }
                else
                {
                    if (_patrolPointIndex < 0)
                    {
                        _patrolPointIndex = UnityEngine.Random.Range(0, _patrolPoints.Length); // 
                    }
                    else
                    {
                        _patrolPointIndex =
                            (_patrolPointIndex + 1) %
                            _patrolPoints.Length; // '%' calculates the remainder and wraps it back around. 
                    }

                    SetDestination(_patrolPoints[_patrolPointIndex]);
                    EnteredState = true;
                }
            }

            return EnteredState;
        }


        public override void UpdateState()
        {
            //TODO: need to make sure we've successfully entered the state
            if (EnteredState)
            {
                if (Vector3.Distance(_navMeshAgent.transform.position,
                    _patrolPoints[_patrolPointIndex].transform.position) <= 1f)
                {
                    //logic
                }
            }
        }

        public void SetDestination(GuardPatrolPoint destination)
        {
            if (_navMeshAgent !=null && destination != null)
            {
                _navMeshAgent.SetDestination(destination.transform.position);
            }
            
        }
    }
}