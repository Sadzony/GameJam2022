using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CapsuleCollider capsuleCollider;
    Rigidbody rb;

    // Forces for leaning and accel.
    public float leanForce = 0.5f;
    public float accelForce = 0.5f;

    private KeyCode lastPressedAccelKey;

    public GameObject debug;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleLeaning(KeyCode.LeftArrow, KeyCode.RightArrow);
        HandleAcceleration(KeyCode.X, KeyCode.Z);

        // Handle Steering

        if (transform.rotation.z < 0.1f)
        {
            float diff = transform.rotation.z * -1;
            Quaternion delta = Quaternion.Euler(new Vector3(0, diff * 2, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * delta);
        }
        else if(transform.rotation.z > 0.1f)
        {
            float diff = transform.rotation.z * 1;
            diff = -diff;
            Quaternion delta = Quaternion.Euler(new Vector3(0, diff * 2, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * delta);
        }
    }

    public void HandleLeaning(KeyCode left, KeyCode right)
    {
        if (Input.GetKeyDown(left))
        {
            rb.AddForceAtPosition(new Vector3(-leanForce, 0, 0), new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(right))
        {
            rb.AddForceAtPosition(new Vector3(leanForce, 0, 0), new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), ForceMode.Impulse);
        }
    }

    public void HandleAcceleration(KeyCode left, KeyCode right) 
    {
        if (Input.GetKeyDown(left) && lastPressedAccelKey != left)
        {
            rb.AddForce(transform.forward * accelForce, ForceMode.Impulse);
            lastPressedAccelKey = left;
        }

        if (Input.GetKeyDown(right) && lastPressedAccelKey != right)
        {
            rb.AddForce(transform.forward * accelForce, ForceMode.Impulse);
            lastPressedAccelKey = right;
        }
    }
}
