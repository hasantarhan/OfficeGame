using System;
using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts
{
    public class WhiteBoardState : State
    {
        public Transform penStartPosition;
        public Pen pen;
        public WhiteBoard whiteBoard;
        public override void Enter()
        {
            base.Enter();
            whiteBoard.ColliderEnabled(true);
            whiteBoard.onClicked += NextState;
        }

        public override void Exit()
        {
            base.Exit();
            whiteBoard.ColliderEnabled(false);
            whiteBoard.onClicked -= NextState;
        }

        private void NextState()
        {
            GetComponent<ObjectShaker>().enabled = false;
            fsm.NextState();
        }
    }
}