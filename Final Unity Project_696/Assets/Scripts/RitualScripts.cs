using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualScripts : MonoBehaviour
{
    public GameObject connectedCandle; 
    
    private void OnTriggerEnter(Collider other) { 
        if (this.gameObject.tag == other.gameObject.tag) {
            connectedCandle.SetActive(true); 
        }
    }
}
