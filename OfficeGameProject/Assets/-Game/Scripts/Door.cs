using System;
using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts
{
    public class Door : MonoBehaviour,IClickable
    {
        [SerializeField] private Transform doorMesh;
        public bool CanClick { get; set; }
        public Action onClick;
        
        public void OnClick()
        {
            Open();
        }

        private void Open()
        {
            doorMesh.DOLocalRotate(new Vector3(0,45,0), 0.5f).SetEase(Ease.OutSine);
            onClick?.Invoke();
        }
    }
}