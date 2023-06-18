using System;
using UnityEngine;

namespace _Game.Scripts
{
    [CreateAssetMenu(fileName = "InfoData", menuName = "Katana/Info Data", order = 0)]
    public class InfoData : ScriptableObject
    {
        public Action<string> onInfoUpdated;
        private string info;

        public string Info => info;

        public void Raise(string info)
        {
            this.info = info;
            onInfoUpdated?.Invoke(info);
        }
    }
}