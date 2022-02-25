using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName="Idle", menuName="Unity-FSM/States/Idle", order =1)]
    public class Idle : State
    {
        public override bool EnterState()
        {
            base.EnterState(); //calls the base implementation thats in the abstract class
            Debug.Log("Entered Idle State");
            EnteredState = true;
            return EnteredState;
        }

        public override void UpdateState()
        {
            Debug.Log("Upating Idle State");
        }

        public override bool ExitState()
        {
            base.ExitState();
            Debug.Log("Exiting Idle State");
            return true;
        }
    }
}