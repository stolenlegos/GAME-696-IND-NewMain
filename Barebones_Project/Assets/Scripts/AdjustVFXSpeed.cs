using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AdjustVFXSpeed : MonoBehaviour {
  [SerializeField] private float timeScale;
  [SerializeField] private VisualEffect VFX;

  void Start() {
    VFX = GetComponent<VisualEffect>();
    if (gameObject.tag == "Half Ghost") {
      VFX.playRate = 1f;
    } else {
      VFX.playRate = timeScale;
    }
  }
}
