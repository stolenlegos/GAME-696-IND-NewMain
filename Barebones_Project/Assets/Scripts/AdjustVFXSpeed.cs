using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AdjustVFXSpeed : MonoBehaviour {
  [SerializeField] private float timeScale = 0.25f;
  [SerializeField] private VisualEffect VFX;

  void Start() {
    VFX = GetComponent<VisualEffect>();
    VFX.playRate = timeScale;
  }
}
