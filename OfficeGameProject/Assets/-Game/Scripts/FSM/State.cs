using System;
using UnityEngine;

namespace _Game.Scripts
{
    public abstract class State : MonoBehaviour
    {
        public event Action onStateEnter;
        public event Action onStateExit;
        public string info;
        public InfoData infoData;
        protected FSM fsm;

        public void Initialize(FSM fsm)
        {
            this.fsm = fsm;
        }
        

        public virtual void Enter()
        {
            gameObject.SetActive(true);
            infoData.Raise(info);            
            onStateEnter?.Invoke();
        }

        public virtual void Exit()
        {
            gameObject.SetActive(false);
            onStateExit?.Invoke();
        }
    }
}