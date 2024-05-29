using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Camera Collider script attached to " + gameObject.name);
    }

    // on collision enter log the name of the object collided with
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Camera collided with " + collision.gameObject.name);
    }
    
    // on trigger enter log the name of the object collided with
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Camera triggered with " + other.gameObject.tag);
    }
}
