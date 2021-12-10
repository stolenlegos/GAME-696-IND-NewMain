using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEvents {
  public delegate void MatchAction ();
  public static event MatchAction PickedUp;
  public static event MatchAction PutedDown;


  public static void PickUp() {

  }


  public static void PutDown() {

  }
}
