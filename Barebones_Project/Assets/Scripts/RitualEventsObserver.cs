using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualEventsObserver : MonoBehaviour
{
    [SerializeField]
    private int numActiveCandles;
    [SerializeField]
    private int numActiveElems; 
    private bool circleActive; 
    public GameObject halfGhost; 
    public GameObject fullGhost; 
    private void Update() { 
        if (numActiveCandles == 4 || numActiveElems == 4) {
            //activate the half ghost object
            halfGhost.SetActive(true); 
        }

        if (numActiveCandles == 4 && numActiveElems == 4) {
            halfGhost.SetActive(false); 
            fullGhost.SetActive(true); 
        }
    }

    private void OnEnable() {
        RitualScripts.IncrementElem += IncrementCount;
        MatchLight.IncrementCandle += IncrementCount;  
    }
    
    private void IncrementCount(int num, string itemType) {
        if (itemType == "element") {
            numActiveElems += num; 
        }
        if (itemType == "candle") {
            numActiveCandles += num;
        }
    }
}
