using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEvents {
  public delegate void MatchAction (bool tf, GameObject match);
  public static event MatchAction ChangeHold;
  public static event MatchAction SageChangeHold;


  public static void PickUpDrop(bool tf, GameObject match) {
    if (ChangeHold != null) {
      ChangeHold(tf, match);
    }
  }

  public static void PickUpDropSage(bool tf, GameObject sage) {
    if (SageChangeHold != null) {
      SageChangeHold(tf, sage);
    }
  }
}
