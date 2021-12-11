using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStrike : MonoBehaviour
{
  private bool matchInHand;
  private GameObject match;

  void Start() {
    MatchEvents.ChangeHold += ChangeBool;
    matchInHand = false;
  }

    private void OnMouseEnter() {
        if (matchInHand) {
            match.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void ChangeBool(bool tf, GameObject obj) {
      match = obj;
      matchInHand = tf;
    }
}
