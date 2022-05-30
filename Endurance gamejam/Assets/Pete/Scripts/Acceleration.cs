using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField]
    private float speed = 10.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(Vector3.forward * speed * Time.deltaTime);
    }
}
