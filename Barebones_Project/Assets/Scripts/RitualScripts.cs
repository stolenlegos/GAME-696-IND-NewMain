using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class RitualScripts : MonoBehaviour
{
    public GameObject connectedLight;
    public bool elemAdded; 

    private void Start() { 
        elemAdded = false; 
    } 

    public static event Action<int,string> IncrementElem; 
    private void OnTriggerEnter(Collider other) { 
        if (this.gameObject.tag == other.gameObject.tag) {
            connectedLight.SetActive(true);
            if (!elemAdded) {
                IncrementElem?.Invoke(1,"element"); 
                elemAdded = true; 
            }
        }
    }

    //This is never going to happen because of the way pickup currently works
    private void OnTriggerExit(Collider other) { 
        if (this.gameObject.tag == other.gameObject.tag) {
            connectedLight.SetActive(false);
            if (elemAdded) {
                IncrementElem?.Invoke(-1,"element"); 
                elemAdded = false; 
            }
        }
    }

    private void OnEnable() { 
        RitualEventsObserver.NegateGlowingSpots += ReverseElements; 
    }

    private void OnDisable() {
        RitualEventsObserver.NegateGlowingSpots -= ReverseElements; 

    }

    private void ReverseElements() {
        connectedLight.SetActive(false); 
        elemAdded = false; 
        IncrementElem?.Invoke(-1,"element"); 
    }
    
}
