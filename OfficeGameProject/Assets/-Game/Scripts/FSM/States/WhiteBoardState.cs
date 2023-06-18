using System;
using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts
{
    public class WhiteBoardState : State
    {
        [SerializeField] private Transform penStartPosition;
        [SerializeField] private Pen pen;
        [SerializeField] private WhiteBoard whiteBoard;
        public override void Enter()
        {
            whiteBoard.ColliderEnabled(true);
            whiteBoard.onClicked += NextState;
            whiteBoard.CanClick = true;
            stateEnterEvent.stateMainObject = whiteBoard.gameObject;
            base.Enter();

        }

        public override void Exit()
        {
            base.Exit();
            whiteBoard.ColliderEnabled(false);
            whiteBoard.onClicked -= NextState;
            whiteBoard.CanClick = false;
        }

        private void NextState()
        {
            GetComponent<ObjectShaker>().enabled = false;
            fsm.NextState();
        }
    }
}