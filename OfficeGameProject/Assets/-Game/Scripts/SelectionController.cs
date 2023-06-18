using System;
using _Game.Code.Utils;
using Lean.Touch;
using UnityEngine;

namespace _Game.Scripts
{
    public class SelectionController : Singleton<SelectionController>
    {
        public Transform currentClickable;
        public Transform inventoryPoint;

        private void OnEnable()
        {
            LeanTouch.OnFingerDown += SelectObject;
        }

        private void OnDisable()
        {
            LeanTouch.OnFingerDown -= SelectObject;
        }

        private void SelectObject(LeanFinger obj)
        {
            var ray = Camera.main.ScreenPointToRay(obj.ScreenPosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.TryGetComponent(out IClickable clickable))
                {
                    if (clickable.CanClick)
                    {
                        currentClickable = hit.collider.transform;
                        clickable.OnClick();
                    }
                }
            }
        }
    }
}