using System;
using UnityEngine;

namespace _Game.Scripts.CameraSystem
{
    public class CameraPoint : MonoBehaviour
    {
        private void OnEnable()
        {
            CameraController.Instance.SetCameraPoint(this);
        }

        private void OnDisable()
        {
           // CameraController.Instance.SetCameraPoint(null);
        }
    }
}