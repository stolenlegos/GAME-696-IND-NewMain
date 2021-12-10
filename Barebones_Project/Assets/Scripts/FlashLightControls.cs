using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightControls : MonoBehaviour
{
    private bool flashLightState = true; 
    private GameObject flashlight; 

    private void Start() { 
        flashlight = GameObject.Find("Flash Light"); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            if (flashLightState) { 
                flashlight.GetComponent<Light>().enabled = false;
                flashLightState = false; 
            } else if (!flashLightState) {
                flashlight.GetComponent<Light>().enabled = true; 
                flashLightState = true; 

            }
        }
    }
}
