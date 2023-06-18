using UnityEngine;

namespace _Game.Scripts
{
    public class PenPhysics : MonoBehaviour
    {
        [SerializeField] private float tiltAngle = 10f; 
        [SerializeField] private float rotationDamping = 5f; 
        [SerializeField] private float reverseRotationDamping = 5f;
        private Vector3 previousPosition;
        private Quaternion initialRotation;

        private void Start()
        {
            previousPosition = transform.position;
            initialRotation = transform.localRotation;
        }

        private void FixedUpdate()
        {
            var direction = transform.position - previousPosition;

            var tiltRotation = Quaternion.Euler(
                0,
                direction.z * tiltAngle,
                -direction.y * tiltAngle
            );

            var targetRotation = tiltRotation * initialRotation;
            transform.localRotation =
                Quaternion.Lerp(transform.localRotation, targetRotation, rotationDamping * Time.deltaTime);
            
            previousPosition = transform.position;

            if (direction.magnitude < 0.001f)
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, initialRotation,
                    reverseRotationDamping * Time.deltaTime);
            }
        }
    }
}