using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Bowl : MonoBehaviour {

  public bool candyAdded; 
  public static event Action<int,string> IncrementCandy; 
  private void OnCollisionEnter(Collision other) { 
    if (other.collider.tag == "Bowl") {
      if (!candyAdded){
        IncrementCandy?.Invoke(1,"candy");
        candyAdded = true; 
      }
    }
  }

  // private void Update() { 
  //   if (transform.parent != null) { 
  //     if (transform.parent.gameObject.name == "Destination") {
  //       candyAdded = false; 
  //       IncrementCandy?.Invoke(-1,"candy"); 
  //     }
  //   }
  // }
}
