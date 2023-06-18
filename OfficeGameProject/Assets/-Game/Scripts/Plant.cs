using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts
{
    public class Plant : MonoBehaviour
    {
        public Transform glassPoint;
        public Transform plantMesh;
        public Action onGrowed;
        public void Grow()
        {
            plantMesh.DOScaleY(1, 0.1f).SetEase(Ease.OutSine);
            plantMesh.DOScaleX(1, 0.25f).SetEase(Ease.OutBack);
            plantMesh.DOScaleZ(1, 0.25f).SetEase(Ease.OutBack).onComplete+= delegate
            {
                onGrowed?.Invoke();
            };

        }
    }
}