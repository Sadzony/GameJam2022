using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
public class BikeAcceleration : MonoBehaviour
{
    public bool stop = false;
    public float speedForSparks;
    [HideInInspector] public bool sparking = false;
    public GameObject sparksPrefab;
    private Transform sparkStart;
    [SerializeField] private float torquePower;
    [SerializeField] private float speedPower;
    [HideInInspector] public Rigidbody rb;

    bool applyForce = false;
    bool braking = false;
    string lastButton = "";

    AudioSource audioPedal;
    AudioSource sparkAudio;

    CinemachineVirtualCamera vcam;
    float fov;
    float fovTimeStart = 0;
    float fovTimeStop = 0;

    //UI Variables
    [SerializeField] private Image directionArrowLeft;
    [SerializeField] private Image directionArrowRight;

    bool coroutineRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        fov = vcam.m_Lens.FieldOfView;
        audioPedal = GetComponent<AudioSource>();
        sparkStart = transform.GetChild(0).Find("sparksStart");
        sparkAudio = sparkStart.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        directionArrowLeft.enabled = false;
        directionArrowRight.enabled = false;
    }

    private void Update()
    {
        if (!applyForce)
        {
            if ((Input.GetKeyDown("left") || Input.GetMouseButtonDown(0)) && lastButton != "left")
            {
                audioPedal.Play();
                EnableLeftArrow();
                applyForce = true;
                lastButton = "left";
            }
            else if ((Input.GetKeyDown("right") || Input.GetMouseButtonDown(1)) && lastButton != "right")
            {
                audioPedal.Play();
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
                    rb.AddTorque(Vector3.left * torquePower * (Mathf.Abs(rb.angularVelocity.x) / 5), ForceMode.Force);
                }
                if (rb.velocity.z > 0)
                {
                    rb.AddForce(Vector3.back * speedPower * (Mathf.Abs(rb.velocity.z) / 5), ForceMode.Force);
                    if (!coroutineRunning)
                    {
                        StartCoroutine(sparks());
                    }
                }
            }
        }
        else
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
        if(rb.velocity.z > speedForSparks)
        {
            fovTimeStop = 0;
            fovTimeStart += Time.deltaTime;
            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, fov + 10, fovTimeStart);
            if (!coroutineRunning)
            {
                StartCoroutine(sparks());
            }
        }
        else
        {
            fovTimeStart = 0;
            fovTimeStop += Time.deltaTime;
            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, fov, fovTimeStop);
            sparking = false;
        }
        if (!coroutineRunning)
        {
            sparkAudio.Stop(); 
        }
    }
    IEnumerator sparks()
    {
        if (!sparkAudio.isPlaying)
        {
            sparkAudio.Play();
        }
        if (!braking)
        {
            sparking = true;
        }
        coroutineRunning = true;
        Instantiate(sparksPrefab, sparkStart);
        yield return new WaitForSeconds(0.1f);
        coroutineRunning = false;
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
