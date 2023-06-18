using UnityEngine;

namespace _Game.Scripts
{
    public class WaterState : State
    {

        public WaterBottle waterBottle;
        public override void Enter()
        {
            base.Enter();
            waterBottle.onClicked += NextState;
            waterBottle.ColliderEnabled(true);
        }

        public override void Exit()
        {
            base.Exit();
            waterBottle.onClicked -= NextState;
            waterBottle.ColliderEnabled(false);
        }
        
        private void NextState()
        {
            GetComponent<ObjectShaker>().enabled = false;
            fsm.NextState();
        }
    }
}