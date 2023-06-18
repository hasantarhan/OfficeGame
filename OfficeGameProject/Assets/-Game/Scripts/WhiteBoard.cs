using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class WhiteBoard : MonoBehaviour,IClickable,IColorable
    {
        public Transform drawPlane;
        public Action onClicked;
        public Collider collider;

        public bool CanClick { get; set; }

        private void Awake()
        {
            collider = GetComponent<Collider>();
        }

        public void OnClick()
        {
            onClicked?.Invoke();
        }

        public void DrawMode()
        {
            drawPlane.gameObject.SetActive(true);
        }
        public void ColliderEnabled(bool enabled)
        {
            collider.enabled = enabled;
        }

        public void ChangeColor(Color color)
        {
            
        }
    }
}