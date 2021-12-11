using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObject
{
    

    public GameObject halfGhost; 
    public GameObject fullGhost; 
    public string ghostName;
    public string ghostObject;  
    public bool ghostActive; 
    
    public GhostObject(GameObject _halfGhost, GameObject _fullGhost, string _ghostName, string _ghostObject, bool _ghostActive) {
        halfGhost = _halfGhost; 
        fullGhost = _fullGhost; 
        ghostName = _ghostName; 
        ghostObject = _ghostObject; 
        ghostActive = _ghostActive; 
    }
}
