using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualEventsObserver : MonoBehaviour
{
    [SerializeField]
    private int numActiveCandles;
    [SerializeField]
    private int numActiveElems;
    private int numActiveAshes;  
    private bool circleActive;
    [SerializeField]
    private List<GameObject> ghostOrbs;
    [SerializeField]
    private List<GhostObject> _ghosts; 
    public GameObject currentGhostState;
    private bool _halfGhost; 
    private bool _fullGhost;  
    
    private void Start() { 
        _ghosts = new List<GhostObject>(); 
        _halfGhost = false;
        _fullGhost = false; 
        GhostObject undecided = new GhostObject(ghostOrbs[0], ghostOrbs[1], "Undecided", "N/A", false);
        GhostObject ian = new GhostObject(ghostOrbs[2], ghostOrbs[3], "Ian", "Photo", false );
        GhostObject aunt = new GhostObject(ghostOrbs[4], ghostOrbs[5], "Aunt", "Comb", false);
        GhostObject chuck = new GhostObject(ghostOrbs[6], ghostOrbs[7], "Chuck","Knife", false);
        _ghosts.Add(undecided);
        _ghosts.Add(ian);
        _ghosts.Add(aunt); 
        _ghosts.Add(chuck);  
        SetCurrentGhostSet();
    }
    private void Update() { 
        if (numActiveCandles == 4) {
            //activate the half ghost object
            _halfGhost = true; 
            SetCurrentGhostSet();  
        }

        if (numActiveCandles == 4 && numActiveElems == 4
        && numActiveAshes == 8) {
            _halfGhost = false;
            _fullGhost = true;  
            SetCurrentGhostSet(); 
        }
    }

    private void OnEnable() {
        RitualScripts.IncrementElem += IncrementCount;
        MatchLight.IncrementCandle += IncrementCount;
        AshStepEvent.IncrementAshes += IncrementCount; 
        GhostObjDetectTable.ToggleBool += ToggleGhostObjectBool;   
    }

    private void OnDisable() {
        RitualScripts.IncrementElem -= IncrementCount;
        MatchLight.IncrementCandle -= IncrementCount;
        AshStepEvent.IncrementAshes -= IncrementCount;   
        GhostObjDetectTable.ToggleBool -= ToggleGhostObjectBool;   

    }
    
    private void IncrementCount(int num, string itemType) {
        if (itemType == "element") {
            numActiveElems += num; 
        }
        if (itemType == "candle") {
            numActiveCandles += num;
        }
        if (itemType == "ashes") {
            numActiveAshes += num; 
        }
    }

    private void ToggleGhostObjectBool(bool ghostState, string ghostItemName) {
        foreach (GhostObject ghost in _ghosts) {
            if (ghost.ghostObject == ghostItemName) {
                ghost.ghostActive = ghostState; 
                return; 
            }
        }
        SetCurrentGhostSet(); 
    }

    private void SetCurrentGhostSet() {
        int numVoicesActive = 0; 
        foreach (GhostObject ghost in _ghosts) {
            if (ghost.ghostActive)
                numVoicesActive++; 
        }
        if (numVoicesActive != 1) {
            if (_halfGhost)
                SwapGhost(_ghosts[0].halfGhost);
            if (_fullGhost)
                SwapGhost(_ghosts[0].fullGhost); 
        } else {
            for (int i = 0; i < _ghosts.Count; i++) { 
                if (_ghosts[i].ghostActive) {
                    if (_halfGhost)
                        SwapGhost(_ghosts[i].halfGhost);
                    if (_fullGhost)
                        SwapGhost(_ghosts[i].fullGhost);
                }
            } 
        }
    }

    private void SwapGhost(GameObject newGhost) { 
                currentGhostState.SetActive(false); 
                currentGhostState = newGhost; 
                currentGhostState.SetActive(true); 
    }
}
