using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class SagePickedUp : MonoBehaviour
{
    public static event Action<bool> playerSageUpdate; 
    private void Update() { 
        if (transform.parent != null) {
            if (transform.parent.gameObject.name == "Destination") { 
                playerSageUpdate?.Invoke(true); 
            } else {
                playerSageUpdate?.Invoke(false); 
            }
        } else { 
            playerSageUpdate?.Invoke(false); 
        }
    }
}
