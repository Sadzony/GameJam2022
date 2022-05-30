using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeAcceleration : MonoBehaviour
{
    public bool stop = false;
    [SerializeField] private float torquePower;
    [HideInInspector] public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stop)
        {
            rb.AddTorque(Vector3.right * torquePower);
        }
        else
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
