using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Enemy;

namespace Enemy
{
    public class GuardPatrolPoint : MonoBehaviour
    {
        [SerializeField] protected float _debugDrawRadius = 0.3f;
        [SerializeField] private float _connectivityRadius = 2.3f;

        private List<GuardPatrolPoint> _connections;

        
        public void Start()
        {
            GameObject[] allWaypoints = new[] {GameObject.FindGameObjectWithTag("PatrolPoint")};
            _connections = new List<GuardPatrolPoint>();

            for (int i = 0; i < allWaypoints.Length; i++)
            {
                GuardPatrolPoint nextWaypoint = allWaypoints[i].GetComponent<GuardPatrolPoint>();

                if (nextWaypoint != null)
                {
                    if (Vector3.Distance(transform.position, nextWaypoint.transform.position) <= _connectivityRadius &&
                        nextWaypoint != this)
                    {
                        _connections.Add(nextWaypoint);
                    }

                }
            }
            
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _debugDrawRadius);
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _connectivityRadius);
        }
    }
}
