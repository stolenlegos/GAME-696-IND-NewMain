using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTimer : MonoBehaviour
{
    private float timer; 
    
    private void OnEnable() {
        timer = 30.0f; 
    }
    
    private void Update() { 
        if (timer > 0) {
            timer -= Time.deltaTime; 
        } else {
            gameObject.SetActive(false); 
        }
    }
}
