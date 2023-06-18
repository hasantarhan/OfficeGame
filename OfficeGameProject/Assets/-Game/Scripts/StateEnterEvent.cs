using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts
{
    [CreateAssetMenu(fileName = "StateEnter", menuName = "Katana/State Enter Event", order = 0)]
    public class StateEnterEvent : ScriptableObject
    {
        public Action<State> onStateEnter;
        public GameObject stateMainObject;

        public void Raise(State state)
        {
            onStateEnter?.Invoke(state);
        }
    }
}