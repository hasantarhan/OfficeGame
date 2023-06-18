using System;
using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts
{
    public class Trash : MonoBehaviour, IClickable
    {
        public bool CanClick { get; set; }
        public Action onClicked;
        public Transform glassThrowPoint;
        [SerializeField] private Collider collider;

        private void Awake()
        {
            collider = GetComponent<Collider>();
            CanClick = true;
        }

        public void OnClick()
        {
            onClicked?.Invoke();
        }

        public void ColliderEnabled(bool enabled)
        {
            collider.enabled = enabled;
        }
    }
}