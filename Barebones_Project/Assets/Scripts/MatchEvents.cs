using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEvents {
  public delegate void MatchAction ();
  public static event MatchAction PickedUp;
  public static event MatchAction PutedDown;


  public static void PickUp() {
    if (PickedUp != null) {
      PickedUp();
    }
  }


  public static void PutDown() {
    if (PutedDown != null) {
      PutedDown();
    }
  }
}
