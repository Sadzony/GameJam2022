using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeSteering : MonoBehaviour
{
    [Header("Steering")]
    public float steeringPower = 1;
    public float steeringDampener = 10;

    public float steerMinimum = 5;

    public float changeDirectionMultiplier = 2.5f;

    [Header("Leaning")]
    public float leaningPower = 1;
    public float leaningDampener = 10;

    [Header("Input")]
    public float inputPower;
    float steeringAxisInput;

    Rigidbody steeringRigidbody;
    Rigidbody accelerationRigidbody;

    BikeAcceleration accelerationScript;

    Quaternion startRotation;
    Quaternion currentRotation;

    Vector3 offset;

    void Start()
    {
        steeringRigidbody = GetComponent<Rigidbody>();
        accelerationRigidbody = transform.parent.GetComponent<Rigidbody>();
        accelerationScript = transform.parent.GetComponent<BikeAcceleration>();
        startRotation = transform.rotation;
        offset = transform.position - transform.parent.position;
        currentRotation = startRotation;

    }

    // Update is called once per frame
    void Update()
    {
        steeringAxisInput = Input.GetAxisRaw("Horizontal") * inputPower;
        transform.position = transform.parent.position + offset;
    }
    private void FixedUpdate()
    {
        float angle = Vector3.SignedAngle(Vector3.up, transform.up, Vector3.forward);
        float steeringTorque = (steeringPower * Mathf.Abs(angle)) / steeringDampener;
        float leaningTorque = (leaningPower * Mathf.Abs(angle)) / leaningDampener;

        if(steeringTorque < steerMinimum)
        {
            steeringTorque = steerMinimum;
        }

        float angleToGround = Vector3.SignedAngle(transform.up, Vector3.right, Vector3.forward);

        if (angleToGround < -10)
        {
            //above ground
            if (angle < 0)
            {
                //if moving opposite direction
                if(accelerationRigidbody.angularVelocity.z > 0)
                {
                    AddTorqueRight(accelerationRigidbody, steeringTorque * changeDirectionMultiplier);
                }
                AddTorqueRight(accelerationRigidbody, steeringTorque);
                AddTorqueRight(steeringRigidbody, leaningTorque);
                AddSpeedRight(accelerationRigidbody, steeringTorque / 2);
            }
            else
            {
                if (accelerationRigidbody.angularVelocity.z < 0)
                {
                    AddTorqueLeft(accelerationRigidbody, steeringTorque * changeDirectionMultiplier);
                }
                AddTorqueLeft(accelerationRigidbody, steeringTorque);
                AddTorqueLeft(steeringRigidbody, leaningTorque);
                AddSpeedLeft(accelerationRigidbody, steeringTorque / 2);
            }

            //input steering
            if (steeringAxisInput != 0)
            {
                AddTorqueRight(steeringRigidbody, steeringAxisInput);
            }
        }
        else
        {
            //dead
            steeringRigidbody.angularVelocity = new Vector3(0, 0, 0);
            accelerationRigidbody.angularVelocity = new Vector3(0, 0, 0);
            accelerationScript.stop = true;
        }
    }
    public void AddTorqueLeft(Rigidbody rb, float power)
    {
        rb.AddTorque(Vector3.forward * power);
    }
    public void AddTorqueRight(Rigidbody rb, float power)
    {
        rb.AddTorque(Vector3.back * power);
    }
    public void AddSpeedLeft(Rigidbody rb, float power)
    {
        rb.AddForce(Vector3.left * power);
    }
    public void AddSpeedRight(Rigidbody rb, float power)
    {
        rb.AddForce(Vector3.right * power);
    }
}
