using UnityEngine;

namespace _Game.Scripts
{
    public class DoorState : State
    {
        [SerializeField] private Door door;
        [SerializeField] private GameObject doorButton;
        public override void Enter()
        {
            stateEnterEvent.stateMainObject = door.gameObject;
            door.CanClick = true;
            doorButton.SetActive(true);
            door.onClick += OnDoorClicked;
            base.Enter();
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