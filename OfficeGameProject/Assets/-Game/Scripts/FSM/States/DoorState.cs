﻿using UnityEngine;

namespace _Game.Scripts
{
    public class DoorState : State
    {
        [SerializeField] private Door door;
        [SerializeField] private GameObject doorButton;
        public override void Enter()
        {
            base.Enter();
            door.CanClick = true;
            doorButton.SetActive(true);
            door.onClick += OnDoorClicked;
        }

        public override void Exit()
        {
            door.onClick -= OnDoorClicked;
            base.Exit();
            door.CanClick = false;
        }

        private void OnDoorClicked()
        {
            GameController.Instance.FinishGame(true);
        }
    }
}