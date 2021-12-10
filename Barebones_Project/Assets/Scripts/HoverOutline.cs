using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOutline : MonoBehaviour
{

    public Material noHoverMat;
    public Material hoverMat;
    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    private void OnMouseEnter() {
        meshRenderer.material = hoverMat;
        Debug.Log("MATERIAL ACTIVATED");
    }

    private void OnMouseExit() {
        meshRenderer.material = noHoverMat;
        Debug.Log("MATERIAL ACTIVATED");
    }
}
