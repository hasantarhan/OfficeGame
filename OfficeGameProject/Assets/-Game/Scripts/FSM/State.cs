using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts
{
    public abstract class State : MonoBehaviour
    {
        public StateEnterEvent stateEnterEvent;
        public StateExitEvent stateExitEvent;
        public InfoEvent ınfoEvent;
        public string info; 
        protected FSM fsm;

        public void Initialize(FSM fsm)
        {
            this.fsm = fsm;
        }
        

        public virtual void Enter()
        {
            gameObject.SetActive(true);
            stateEnterEvent.Raise(this);
            ınfoEvent.Raise(info);            
         
        }

        public virtual void Exit()
        {
            gameObject.SetActive(false);
            stateExitEvent.Raise(this);
        
        }
    }
}