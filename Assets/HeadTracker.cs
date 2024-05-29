using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTracker : MonoBehaviour
{
    public GameObject head;
    void FixedUpdate()
    {
        transform.position = head.transform.position;
        transform.rotation = head.transform.rotation;
    }
    
    // On collision enter log the name of the object collided with
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Head collided with " + collision.gameObject.name);
    }
    
    // On trigger enter log the name of the object collided with
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Head triggered with " + other.gameObject.tag);
    }
}
