using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class PenState : State
    {
        [SerializeField] private Pen pen;
        [SerializeField] private Transform penInventoryPoint;
        public override void Enter()
        {
            base.Enter();
            pen.onClick += ShakeDisable;
            pen.onClick += PenGoToInventory;
            pen.onPenInInventory += NextState;
            pen.ColliderEnabled(true);
            pen.CanClick = true;
        }

        private void PenGoToInventory()
        {
            pen.GoToInventoryPoint(penInventoryPoint);
        }

        private void ShakeDisable()
        {
            GetComponent<ObjectShaker>().enabled = false;
        }

        public override void Exit()
        {
            base.Exit();
            pen.onClick -= ShakeDisable;
            pen.onClick -= PenGoToInventory;
            pen.onPenInInventory -= NextState;
            pen.ColliderEnabled(false);
            pen.CanClick = false;

        }
        
        private void NextState()
        {
            fsm.NextState();
        }
    }
    
}