using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class AshStepEvent : MonoBehaviour
{

    [SerializeField]
    private bool _playerHasSage;
    private bool _sageOnFire; 
    [SerializeField]
    private GameObject associatedAshes; 
    private bool _ashesActivated; 
    public static event Action<int,string> IncrementAshes; 

    private void Start() {
        _ashesActivated = false; 
    }

    //Again, in a more polished world, I would combine this into Ritual scripts.
    private void OnTriggerEnter(Collider other) { 
        if (other.tag == "Player" && _playerHasSage && _sageOnFire) { 
            associatedAshes.SetActive(true); 
            if (!_ashesActivated) {
                _ashesActivated = true; 
                IncrementAshes?.Invoke(1,"ashes"); 
            } 
        }
    }

    private void OnEnable() { 
        SagePickedUp.playerSageUpdate += checkPlayerSage; 
        SageStrike.SageOnFire += checkFlamingSage;
        SageLight.SageOnFire += checkFlamingSage; 
 
    }

    private void OnDisable() {
        SagePickedUp.playerSageUpdate -= checkPlayerSage;
        SageStrike.SageOnFire -= checkFlamingSage;
        SageLight.SageOnFire -= checkFlamingSage; 
 
 
    }
    private void checkPlayerSage(bool hasSage) { 
        _playerHasSage = hasSage; 
    }

    private void checkFlamingSage(bool onFire) {
        _sageOnFire = onFire; 
    }
}
