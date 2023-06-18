using UnityEngine;
using UnityEngine.UI;

public class ButtonAboveObject : MonoBehaviour
{
    public Transform RealWorldObject;
    public CanvasScaler canvasScaler;
    RectTransform rectTransform;
 
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        UpdateCanvasReferenceResolution();
    }
    
 
    void UpdateCanvasReferenceResolution()
    {
  
       
    }
 
    public void LateUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(RealWorldObject.position);
        Vector3 uiPos = new Vector3(screenPos.x,  screenPos.y, screenPos.z);
        rectTransform.position = uiPos;  
    }
}