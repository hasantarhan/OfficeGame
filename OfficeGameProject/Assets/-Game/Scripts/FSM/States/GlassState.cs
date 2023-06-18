using UnityEngine;

namespace _Game.Scripts
{
    public class GlassState : State
    {
        [SerializeField] private Glass glass;
        [SerializeField] private Transform glassInventoryPoint;
        public override void Enter()
        {
            base.Enter();
            glass.ColliderEnabled(true);
            glass.onClick += ShakeDisable;
            glass.onClick += GlassGoToInventory;
            glass.onGlassInInventory += NextState;
            glass.CanClick = true;
        }

        public override void Exit()
        {
            base.Exit();
            glass.onGlassInInventory -= NextState;
            glass.onClick -= ShakeDisable;
            glass.onClick -= GlassGoToInventory;
            glass.CanClick = false;
        }

        private void GlassGoToInventory()
        {
            glass.GoToInventoryPoint(glassInventoryPoint);
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