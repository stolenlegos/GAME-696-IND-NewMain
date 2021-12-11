using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualCircle : MonoBehaviour
{
    private void OnEnable() { 
        RitualEventsObserver.ActivateCircle += RitualCircleOn; 
    }

    private void OnDisable() {
        RitualEventsObserver.ActivateCircle -= RitualCircleOn; 
    }

    private void RitualCircleOn() {
        transform.GetChild(0).gameObject.SetActive(true); 
    }
}
