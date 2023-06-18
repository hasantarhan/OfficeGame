using System;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;

namespace _Game.Scripts
{
    public class PlantState : State
    {
        [SerializeField] private Glass glass;
        [SerializeField] private Transform waterPoint;
        [SerializeField] private ParticleSystem waterParticle;
        [SerializeField] private Plant plant;
        public override void Enter()
        {
            stateEnterEvent.stateMainObject = null;
            plant.onGrowed += NextState;
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(delegate
            {
                glass.transform.DOMove(waterPoint.position, 0.5f).onComplete += delegate
                {
                    glass.transform.SetParent(waterPoint);
                    glass.transform.DOLocalMove(Vector3.zero, 0.5f);
                    glass.transform.DORotate(Vector3.zero, 0.5f).onComplete += delegate
                    {
                        glass.transform.SetParent(null);
                        glass.transform.position = waterPoint.position;
                        glass.transform.rotation = waterPoint.rotation;
                        waterParticle.Play();
                    };
                };
            });
            DOTween.Sequence().AppendInterval(3).AppendCallback(delegate
            {
                glass.isDragging = true;
                waterParticle.Stop();
                glass.transform.DOMoveX(glass.transform.position.x + 0.5f, 0.25f);
            });
            base.Enter();

        }

        public override void Exit()
        {
            base.Exit();
            plant.onGrowed -= NextState;
        }

        private void NextState()
        {
            fsm.NextState();
        }
    }
}