using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEvents {
  public delegate void MatchAction (bool tf, GameObject match);
  public static event MatchAction ChangeHold;


  public static void PickUpDrop(bool tf, GameObject match) {
    if (ChangeHold != null) {
      ChangeHold(tf, match);
    }
  }
}
