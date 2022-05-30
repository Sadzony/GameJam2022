using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeSteering : MonoBehaviour
{
    Rigidbody rb;
    Quaternion startRotation;
    Vector3 offset;
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
        startRotation = transform.rotation;
        offset = transform.position - transform.parent.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position + offset;
        transform.rotation = startRotation;
    }
}
