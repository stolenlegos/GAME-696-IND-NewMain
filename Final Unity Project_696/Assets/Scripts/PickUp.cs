using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform destination;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        destination = GameObject.Find("Destination").transform; 
    }

    private void OnMouseDown()
    {
        //if (gameObject.tag == "interactable")
        GetComponent<Collider>().enabled = false; 
        rb.useGravity = false;
        transform.position = destination.position;
        transform.parent = destination;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        //rb.isKinematic = true; 
    }

    private void OnMouseUp()
    {
        GetComponent<Collider>().enabled = true;
        this.transform.parent = null;
        //rb.isKinematic = false;  
        rb.useGravity = true; 
    }
}
