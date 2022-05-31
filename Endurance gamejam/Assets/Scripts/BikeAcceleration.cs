using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BikeAcceleration : MonoBehaviour
{
    public bool stop = false;
    [SerializeField] private float torquePower;
    [SerializeField] private float speedPower;
    [HideInInspector] public Rigidbody rb;

    bool applyForce = false;
    bool braking = false;
    string lastButton = "";


    //UI Variables
    [SerializeField] private Image directionArrowLeft;
    [SerializeField] private Image directionArrowRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        directionArrowLeft.enabled = false;
        directionArrowRight.enabled = false;
    }

    private void Update()
    {
        if (!applyForce)
        {
            if (Input.GetKeyDown("left") && lastButton != "left")
            {
                EnableLeftArrow();
                applyForce = true;
                lastButton = "left";
            }
            else if (Input.GetKeyDown("right") && lastButton != "right")
            {
                EnableRightArrow();
                applyForce = true;
                lastButton = "right";
            }
        }
        if (Input.GetKey("down"))
        {
            braking = true;
        }
        else
        {
            braking = false;
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
                rb.AddForce(Vector3.forward * speedPower, ForceMode.Impulse);
                applyForce = false;
            }
            if (braking)
            {
                if (rb.angularVelocity.x > 0)
                {
                    rb.AddTorque(Vector3.left * torquePower, ForceMode.Force);
                }
                if (rb.velocity.z > 0)
                {
                    rb.AddForce(Vector3.back * speedPower, ForceMode.Force);
                }
            }
        }
        else
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }


    private void EnableLeftArrow()
    {
        directionArrowLeft.enabled = true;
        directionArrowRight.enabled = false;
    }

    private void EnableRightArrow()
    {
        directionArrowLeft.enabled = false;
        directionArrowRight.enabled = true;
    }

   
    

}
