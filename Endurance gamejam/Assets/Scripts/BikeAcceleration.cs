using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeAcceleration : MonoBehaviour
{
    public bool stop = false;
    [SerializeField] private float torquePower;
    [HideInInspector] public Rigidbody rb;

    bool applyForce = false;
    string lastButton = "";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!applyForce)
        {
            if (Input.GetKeyDown("left") && lastButton != "left")
            {
                applyForce = true;
                lastButton = "left";
            }
            else if (Input.GetKeyDown("right") && lastButton != "right")
            {
                applyForce = true;
                lastButton = "right";
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stop)
        {
            if (applyForce)
            {
                rb.AddTorque(Vector3.right * torquePower, ForceMode.Impulse);
                applyForce = false;
            }
        }
        else
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
