using UnityEngine;

namespace _Game.Scripts
{
    public class GlassState : State
    {
        public Glass glass;

        public override void Enter()
        {
            base.Enter();
            glass.ColliderEnabled(true);
            glass.onGlassInInventory += NextState;
            glass.onClick += ShakeDisable;
        }

        public override void Exit()
        {
            base.Exit();
            glass.onGlassInInventory -= NextState;
            glass.onClick -= ShakeDisable;
        }

        private void ShakeDisable()
        {
            GetComponent<ObjectShaker>().enabled = false;
        }

        private void NextState()
        {
            fsm.NextState();
        }
    }
}