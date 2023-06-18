using System;
using _Game.Code.Utils;
using UnityEngine;

namespace _Game.Scripts.CameraSystem
{
    public class CameraController : Singleton<CameraController>
    {
    
        private CameraPoint currentCameraPoint;
        private Vector3 firstPoint;
        private Quaternion firstRotation;

        private void Awake()
        {

            firstPoint = transform.position;
            firstRotation = transform.rotation;
        }
        public void SetCameraPoint(CameraPoint cameraPoint)
        {
            currentCameraPoint = cameraPoint;
            Debug.Log("SetCameraPoint",currentCameraPoint);
            // transform.position = currentCameraPoint.transform.position;
            // transform.rotation = currentCameraPoint.transform.rotation;
        }

        private void Update()
        {
            if (currentCameraPoint == null)
            {
                transform.position = firstPoint;
                transform.rotation = firstRotation;
                return;
            }
            transform.position = Vector3.Lerp(transform.position, currentCameraPoint.transform.position, Time.deltaTime*5);
            transform.rotation = Quaternion.Lerp(transform.rotation, currentCameraPoint.transform.rotation, Time.deltaTime*5);
        }
    }
}