using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class SageLight : MonoBehaviour
{
  private bool candleAdded;
  private bool matchInHand;
  private GameObject match;
  //In a more polished world, I'd combine this with the RitualScripts.
  void Start() {
    MatchEvents.ChangeHold += ChangeBool;
    matchInHand = false;
    gameObject.transform.GetChild(2).gameObject.SetActive(false);
  }

  public static event Action<bool> SageOnFire; 
  private void OnMouseEnter() {
      if (matchInHand && match.transform.GetChild(0).gameObject.activeSelf) {
          gameObject.transform.GetChild(2).gameObject.SetActive(true);
          SageOnFire?.Invoke(true); 

      }
  }

  private void ChangeBool(bool tf, GameObject obj) {
    match = obj;
    matchInHand = tf;
  }
}
