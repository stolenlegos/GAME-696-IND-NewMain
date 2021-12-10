using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform destination;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "interactable" || gameObject.tag == "Fire" || gameObject.tag == "Air"
        || gameObject.tag == "Earth" || gameObject.tag == "Water" || gameObject.tag == "Match")
        {
            GetComponent<Collider>().enabled = false;
            rb.useGravity = false;
            transform.position = destination.position;
            transform.parent = GameObject.Find("Destination").transform;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
            //rb.isKinematic = true;
            if (gameObject.tag == "Match") {
                transform.rotation = new Quaternion(-45, 45, 45, 0);
                MatchEvents.PickUp();
            }
        }
    }

    private void OnMouseUp()
    {
        GetComponent<Collider>().enabled = true;
        this.transform.parent = null;
        //rb.isKinematic = false;
        rb.useGravity = true;
        MatchEvents.PutDown();
    }
}
