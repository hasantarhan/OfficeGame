using System;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;

namespace _Game.Scripts
{
    public class Glass : MonoBehaviour, IClickable
    {
        private Collider collider;
        public Transform inventoryPoint;
        public Action onGlassInInventory;
        public bool isDragging;
        [SerializeField] private float moveSpeed = 1;
        [SerializeField] private ParticleSystem pourWaterParticle;
        public Action onGlassEmpty;
        public Action onClick;
        public bool CanClick { get; set; }

        private void Awake()
        {
            collider = GetComponent<Collider>();
            CanClick = true;
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
            if (isDragging)
            {
                var delta = obj.ScaledDelta;
                var camForward = Vector3.Scale(Camera.main.transform.up, new Vector3(1, 1, 1)).normalized;
                var move = delta.y * camForward + delta.x * Camera.main.transform.right;
                transform.position += move * moveSpeed * Time.deltaTime;
            }
        }

        public void ColliderEnabled(bool enabled)
        {
            collider.enabled = enabled;
        }


        public void OnClick()
        {
            transform.SetParent(inventoryPoint);
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(transform.position.y + 15, 0.5f))
                .Join(transform.DORotate(new Vector3(0, 0, 720), 0.5f, RotateMode.LocalAxisAdd))
                .Join(transform.DOLocalRotate(Vector3.zero, 0.5f))
                .Append(transform.DOMove(inventoryPoint.position, 0.5f))
                .OnComplete(() => { onGlassInInventory?.Invoke(); });
            sequence.Play();
            CanClick = false;
            onClick?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Plant plant))
            {
                PourWater(plant);
            }
        }

        private void PourWater(Plant plant)
        {
            isDragging = false;
            transform.DOMove(plant.glassPoint.position, 0.5f).onComplete += delegate
            {
                transform.SetParent(plant.glassPoint);
                transform.DOLocalMove(Vector3.zero, 0.5f);
                transform.DORotate(new Vector3(-80,0,0), 0.5f).onComplete += delegate
                {
                    transform.SetParent(null);
                    pourWaterParticle.Play();
                };
            };
            DOTween.Sequence().AppendInterval(2f).AppendCallback(delegate
            {
                plant.Grow();
            });
            DOTween.Sequence().AppendInterval(3).AppendCallback(delegate
            {
                pourWaterParticle.Stop();
                onGlassEmpty?.Invoke();
            });
        }
    }
}