using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour {
  private int candyInBowl;

  void Start() {
    candyInBowl = 0;
  }


  void OnTriggerEnter (Collider other) {
    if (other.tag == "Candy") {
      candyInBowl++;
      Debug.Log(candyInBowl);
      if (candyInBowl >= 4) {
        Debug.Log("Light up that candy");
        //signals all candy is in bowl
      }
    }
  }


  void OnTriggerExit(Collider other) {
    if (other.tag == "Candy") {
      candyInBowl--;
    }
  }
}
