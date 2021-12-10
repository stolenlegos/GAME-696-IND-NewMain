using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOutline_DifObject : MonoBehaviour
{
    public GameObject objectToChange; 
    public Material noHoverMat; 
    public Material hoverMat;
    MeshRenderer meshRenderer;  

    void Start()
    {
        meshRenderer = objectToChange.GetComponent<MeshRenderer>();

    }
    
    private void OnMouseEnter() {  
        Debug.Log("codeReached");
        meshRenderer.material = hoverMat; 
    }

    private void OnMouseExit() {
        meshRenderer.material = noHoverMat;
    }
}
