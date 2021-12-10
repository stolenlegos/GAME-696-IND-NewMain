using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStrike : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Match") { 
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
