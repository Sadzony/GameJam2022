using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeAcceleration : MonoBehaviour
{
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
        rb.AddTorque(Vector3.right * torquePower);
    }



    public void AddTorqueLeft(float power)
    {
        rb.AddTorque(Vector3.forward * power);
    }
    public void AddTorqueRight(float power)
    {
        rb.AddTorque(Vector3.back * power);
    }
}
