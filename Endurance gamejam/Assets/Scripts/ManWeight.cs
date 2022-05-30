using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManWeight : MonoBehaviour
{
    public float mass;
    public float dampener;
    Transform playerTransform;
    BikeAcceleration playerScript;
    void Start()
    {
        playerTransform = transform.parent.parent;
        playerScript = playerTransform.GetComponent<BikeAcceleration>();
    }

    // Update is called once per frame
    void Update()
    {

        float angle = Vector3.SignedAngle(Vector3.up, transform.up, Vector3.forward);
        float torquePower = (mass * Mathf.Abs(angle))/dampener;
        if (angle < 0)
        {
            playerScript.AddTorqueRight(torquePower);
        }
        else
        {
            playerScript.AddTorqueLeft(torquePower);
        }
    }
}
