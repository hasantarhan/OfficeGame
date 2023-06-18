using System;
using _Game.Scripts.CameraSystem;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;

namespace _Game.Scripts
{
    public class Pen : MonoBehaviour, IClickable
    {
        [SerializeField] private PenDrawer penDrawer;
        [SerializeField] private Boundaries boundaries;
        public float drawSpeed = 1;
        public Action onPenInInventory;
        public Action onClick;
        private Collider collider;
        private bool drawMode;

        public bool CanClick { get; set; }

        private void Awake()
        {
            collider = GetComponent<Collider>();
            penDrawer.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            LeanTouch.OnFingerUpdate += Move;
        }

        private void OnDisable()
        {
            LeanTouch.OnFingerUpdate -= Move;
        }

        private void Move(LeanFinger obj)
        {
            if (drawMode)
            {
                var delta = obj.ScaledDelta;
                var camForward = Vector3.Scale(Camera.main.transform.up, new Vector3(1, 1, 1)).normalized;
                var move = delta.y * camForward + delta.x * Camera.main.transform.right;
                transform.position += move * drawSpeed * Time.deltaTime;
                transform.position = transform.position.Clamp(boundaries);
            }
        }

        public void OnClick()
        {
            onClick?.Invoke();
            ColliderEnabled(false);
        }
        public void DrawMode(bool enabled)
        {
            drawMode = enabled;
            ColliderEnabled(!enabled);
            transform.SetParent(null);
            penDrawer.gameObject.SetActive(true);
            gameObject.SetActive(enabled);
            if (!enabled)
            {
                penDrawer.transform.SetParent(null);
            }
        }
        public void GoToInventoryPoint(Transform inventoryPoint)
        {
            transform.SetParent(inventoryPoint);
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(transform.position.y + 15, 0.5f))
                .Join(transform.DORotate(new Vector3(0, 0, 720), 0.5f, RotateMode.LocalAxisAdd))
                .Join(transform.DOLocalRotate(Vector3.zero, 0.5f))
                .Append(transform.DOMove(inventoryPoint.position, 0.5f))
                .OnComplete(() => { onPenInInventory?.Invoke(); });
            sequence.Play();
        }
        public void ColliderEnabled(bool enabled)
        {
            collider.enabled = enabled;
        }
    }
}