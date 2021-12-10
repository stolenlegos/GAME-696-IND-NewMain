using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MatchLight : MonoBehaviour
{
    public GameObject connectedCandle;
    private bool candleAdded;
    private bool matchInHand;
    private GameObject match;
    public static event Action<int,string> IncrementCandle;
    //In a more polished world, I'd combine this with the RitualScripts.
    void Start() {
      MatchEvents.ChangeHold += ChangeBool;
      matchInHand = false;
    }

    private void OnMouseEnter() {
        if (matchInHand && match.transform.GetChild(0).gameObject.activeSelf) {
            connectedCandle.SetActive(true);
            if (!candleAdded) {
                IncrementCandle?.Invoke(1,"candle");
                candleAdded = true;
            }
        }
    }
    //This is never going to happen because of the way pickup currently works
    /*private void OnTriggerExit(Collider other) {
        if (this.gameObject.tag == other.gameObject.tag) {
            connectedCandle.SetActive(false);
            if (candleAdded) {
                IncrementCandle?.Invoke(-1,"candle");
                candleAdded = false;
            }
        }
    }*/

    private void ChangeBool(bool tf, GameObject obj) {
      match = obj;
      matchInHand = tf;
      Debug.Log(matchInHand);
    }
}
