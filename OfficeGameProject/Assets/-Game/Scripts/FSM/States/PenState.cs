using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class PenState : State
    {
        [SerializeField] private Pen pen;
        
        public override void Enter()
        {
            base.Enter();
            pen.onPenInInventory += NextState;
            pen.onClick += ShakeDisable;
            pen.ColliderEnabled(true);
        }

        private void ShakeDisable()
        {
            GetComponent<ObjectShaker>().enabled = false;
        }

        public override void Exit()
        {
            base.Exit();
            pen.onPenInInventory -= NextState;
            pen.onClick -= ShakeDisable;
            pen.ColliderEnabled(false);
        }
        
        private void NextState()
        {
            fsm.NextState();
        }
    }
    
}