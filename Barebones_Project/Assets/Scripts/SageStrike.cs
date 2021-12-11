using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SageStrike : MonoBehaviour
{
  private bool sageInHand;
  private GameObject sage;

  void Start() {
    MatchEvents.SageChangeHold += ChangeBool;
    sageInHand = false;
  }

    private void OnMouseEnter() {
        if (sageInHand && gameObject.transform.GetChild(0).gameObject.activeSelf) {
            sage.transform.GetChild(2).gameObject.SetActive(true);
        }
      }

    private void ChangeBool(bool tf, GameObject obj) {
      sage = obj;
      sageInHand = tf;
    }
}
