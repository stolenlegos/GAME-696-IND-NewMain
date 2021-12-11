using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class RitualEventsObserver : MonoBehaviour
{
    [SerializeField]
    private int numActiveCandles;
    [SerializeField]
    private int numActiveElems;
    [SerializeField]
    private int numActiveAshes;
    [SerializeField]
    private int numCandiesInBowl;  
    private bool circleActive;
    [SerializeField]
    private List<GameObject> ghostOrbs;
    [SerializeField]
    private List<GhostObject> _ghosts; 
    public GameObject currentGhostState;
    private bool _halfGhost; 
    private bool _fullGhost;

    public static event Action ActivateCircle;
    private bool _bowlFilledComplete;  
    private bool _magicSageCircleStateComplete;
    private bool _candlesStateComplete; 
    private bool _elementalSpotsStateComplete;  
    
    private void Start() { 
        _magicSageCircleStateComplete = false;
        _candlesStateComplete = false;
        _elementalSpotsStateComplete = false;
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

    public static event Action BlowOutCandles;
    public static event Action NegateGlowingSpots;  
    private void Update() { 
        if (numCandiesInBowl == 4) { 
            _bowlFilledComplete = true; 
        }
        if (numActiveAshes == 8) {
            _magicSageCircleStateComplete = true;
            ActivateCircle?.Invoke();  
        }
        if (numActiveElems == 4 && _magicSageCircleStateComplete) {
            _elementalSpotsStateComplete = true; 
        } else if (numActiveElems == 4 && !_magicSageCircleStateComplete) {
            NegateGlowingSpots?.Invoke(); 
        }
        if (numActiveCandles == 4 && _magicSageCircleStateComplete) {
            _halfGhost = true; 
            SetCurrentGhostSet();
            _candlesStateComplete = true;   
        } else if (numActiveCandles == 4 && !_magicSageCircleStateComplete) { 
            BlowOutCandles?.Invoke(); 
        }
        if (_candlesStateComplete && _elementalSpotsStateComplete
        && _bowlFilledComplete && _magicSageCircleStateComplete) {
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
        Bowl.IncrementCandy += IncrementCount;    
    }

    private void OnDisable() {
        RitualScripts.IncrementElem -= IncrementCount;
        MatchLight.IncrementCandle -= IncrementCount;
        AshStepEvent.IncrementAshes -= IncrementCount;   
        GhostObjDetectTable.ToggleBool -= ToggleGhostObjectBool;  
        Bowl.IncrementCandy -= IncrementCount;   

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
        if (itemType == "candy") {
            numCandiesInBowl += num; 
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
            if (ghost.ghostActive) {
                numVoicesActive++;
            } 
        }
        if (numVoicesActive != 1) {
            if ((currentGhostState.name == _ghosts[0].halfGhost.name && _halfGhost) ||
                (currentGhostState.name == _ghosts[0].fullGhost.name && _fullGhost)) {   
                return;
            } else {
                if (_halfGhost)
                    SwapGhost(_ghosts[0].halfGhost);
                if (_fullGhost)
                    SwapGhost(_ghosts[0].fullGhost);
                return; 
            }
        } else {
            for (int i = 0; i < _ghosts.Count; i++) { 
                if (_ghosts[i].ghostActive) {
                    if ((currentGhostState.name == _ghosts[i].halfGhost.name && _halfGhost) ||
                        (currentGhostState.name == _ghosts[i].fullGhost.name && _fullGhost)) {   
                        return;
                    } else {
                        if (_halfGhost)
                            SwapGhost(_ghosts[i].halfGhost);
                        if (_fullGhost)
                            SwapGhost(_ghosts[i].fullGhost);
                        return; 
                    }
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


