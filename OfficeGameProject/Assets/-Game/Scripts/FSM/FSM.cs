using System;
using Unity.Collections;
using UnityEngine;

namespace _Game.Scripts
{
    public class FSM : MonoBehaviour
    {
        [SerializeField] private State[] states;
        private State currentState;
        private int currentStateIndex;

        private void Awake()
        {
            Initialize();
            ChangeState(states[0]);

        }
        public void Initialize()
        {
            foreach (var state in states)
            {
                state.Initialize(this);
            }
        }

        public T GetState<T>() where T : State, new()
        {
            foreach (var state in states)
            {
                if (state is T)
                {
                    return (T)state;
                }
            }

            return default;
        }

        public void NextState()
        {
            currentStateIndex = (currentStateIndex + 1) % states.Length;
            ChangeState(states[currentStateIndex]);
        }

        public void ChangeState(State state)
        {
            if (currentState != null)
            {
                currentState?.Exit();
            }
            currentState = state;
            if (currentState != null)
            {
                currentState?.Enter();
            }
        }
    }
}