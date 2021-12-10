using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStrike : MonoBehaviour
{
  private bool matchInHand;

  void Awake() {
  //  MatchEvents.PickedUp += MatchPickUp();
  }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Match") {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }


    private void MatchPickUp () {

    }
}
