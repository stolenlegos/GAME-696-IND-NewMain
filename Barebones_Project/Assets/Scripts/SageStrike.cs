using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class SageStrike : MonoBehaviour
{
  private bool sageInHand;
  private GameObject sage;

  void Start() {
    MatchEvents.SageChangeHold += ChangeBool;
    sageInHand = false;
  }

  public static event Action<bool> SageOnFire; 
  private void OnMouseEnter() {
        if (sageInHand && gameObject.transform.GetChild(0).gameObject.activeSelf) {
            sage.transform.GetChild(2).gameObject.SetActive(true);
            SageOnFire?.Invoke(true); 
        }
      }

    private void ChangeBool(bool tf, GameObject obj) {
      sage = obj;
      sageInHand = tf;
    }
}
