using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class WaterBottle : MonoBehaviour,IClickable
    {
        public Action onClicked;
        private Collider collider;

        public bool CanClick { get; set; }

        private void Awake()
        {
            collider = GetComponent<Collider>();
            CanClick = true;
        }

        public void OnClick()
        {
            onClicked?.Invoke();
            ColliderEnabled(false);
        }

        public void ColliderEnabled(bool enabled)
        {
            collider.enabled = enabled;
        }
    }
}