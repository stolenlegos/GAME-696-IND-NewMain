using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class GhostObjDetectTable : MonoBehaviour
{
    [SerializeField]
    private string _ghostItemName; 
    public static event Action<bool,string> ToggleBool; 

    private void OnCollisionEnter(Collision other) { 
        if (other.collider.tag == "Table") {
            ToggleBool?.Invoke(true,_ghostItemName); 
        }
    }

    private void Update() { 
        if (transform.parent != null) { 
            if (transform.parent.gameObject.name == "Destination") 
                ToggleBool?.Invoke(false,_ghostItemName); 
        }
    }
}
