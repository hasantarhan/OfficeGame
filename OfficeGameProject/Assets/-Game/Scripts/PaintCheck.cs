using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts
{
    public class PaintCheck : MonoBehaviour
    {
        public Transform penPoint;
        public GameObject objectPrefab;
        public float yStart;
        public float yEnd;
        public float zStart;
        public float zEnd;
        public int numObjects;
        public List<Vector3> points = new List<Vector3>();
        public Action onPaintComplete;
        private Vector3[] pointTemp;

        private void Start()
        {
        
            CreateObjects();
        }

        private void CreateObjects()
        {
            var yInterval = (yEnd - yStart) / (numObjects - 1);
            var zInterval = (zEnd - zStart) / (numObjects - 1);

            for (int i = 0; i < numObjects; i++)
            {
                for (int j = 0; j < numObjects; j++)
                {
                    var yPos = yStart + i * yInterval;
                    var zPos = zStart + j * zInterval;

                    Vector3 spawnPosition = new Vector3(transform.position.x, yPos, zPos);
                    points.Add(spawnPosition);
                }
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (Vector3.Distance(penPoint.position, points[i]) < 0.1f)
                {
                    points.RemoveAt(i);
                }
            }

            if (points.Count == 0)
            {
                gameObject.SetActive(false);
                onPaintComplete?.Invoke();
            }
        }
    }
}