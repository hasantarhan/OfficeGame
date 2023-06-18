using UnityEngine;

public class PenDrawer : MonoBehaviour
{
    [SerializeField] private Transform penPoint; 
    private LineRenderer lineRenderer;
    private float distanceThreshold = 0.01f;
    private Vector3 lastPosition;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lastPosition = penPoint.position;
    }
    

    private void Update()
    {
        var distance = Vector3.Distance(lastPosition, penPoint.position);

        if (distance >= distanceThreshold)
        {
            DrawLine();
            lastPosition = penPoint.position;
        }
    }

    private void DrawLine()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, penPoint.position);
    }
}