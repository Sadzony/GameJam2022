using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CapsuleCollider capsuleCollider;
    Rigidbody rb;
    NewspaperCannon cannon;

    // Forces for leaning and accel.
    public float leanForce = 0.5f;
    public float accelForce = 0.5f;

    private KeyCode lastPressedAccelKey;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        cannon = GetComponent<NewspaperCannon>();
    }

    // Update is called once per frame
    void Update()
    {
        DebugRotate(KeyCode.A, KeyCode.D);
        DebugMove(KeyCode.W, KeyCode.S);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            cannon.Fire(transform.position, 0.0f, 1000);
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

    public void HandleSteering() 
    {
        if (transform.rotation.z < 0.1f)
        {
            float diff = transform.rotation.z * -1;
            Quaternion delta = Quaternion.Euler(new Vector3(0, diff * 2, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * delta);
        }
        else if (transform.rotation.z > 0.1f)
        {
            float diff = transform.rotation.z * 1;
            diff = -diff;
            Quaternion delta = Quaternion.Euler(new Vector3(0, diff * 2, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * delta);
        }
    }

    public void DebugRotate(KeyCode left, KeyCode right)
    {
        if (Input.GetKey(left))
        {
            transform.Rotate(new Vector3(transform.rotation.x, (transform.rotation.y - 10) * Time.fixedDeltaTime, transform.rotation.z));
        }
        if (Input.GetKey(right))
        {
            transform.Rotate(new Vector3(transform.rotation.x, (transform.rotation.y + 10) * Time.fixedDeltaTime, transform.rotation.z));
        }
    }

    public void DebugMove(KeyCode forward, KeyCode backward)
    {
        if (Input.GetKey(forward))
        {
            rb.AddForce(transform.forward * accelForce, ForceMode.Impulse);
        }

        if (Input.GetKey(backward))
        {
            rb.AddForce(-transform.forward * accelForce, ForceMode.Impulse);
        }
    }
}
