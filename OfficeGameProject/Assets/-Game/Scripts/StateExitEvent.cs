using System;
using UnityEngine;

namespace _Game.Scripts
{
    [CreateAssetMenu(fileName = "StateExitEvent", menuName = "Katana/State Exit Event", order = 0)]
    public class StateExitEvent : ScriptableObject
    {
        public Action<State> onStateExit;
        [SerializeField] private GameObject stateMainObject;

        public void Raise(State state)
        {
            onStateExit?.Invoke(state);
        }
    }
}