using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    [SerializeField] private float bikeSpeed = 10f;
    [SerializeField] private float leanSpeed = 5f;

   
    private Rigidbody rb;

    [SerializeField] private Vector3 pivot;

    Vector3 eulAngles;

    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float random = Random.Range(0, 2);

        rotation = new Vector3(rotation.x % 180f, rotation.y % 180f, rotation.z % 180f);
        eulAngles = new Vector3(eulAngles.x % 180f, eulAngles.y % 180f, eulAngles.z % 180f);

        MovePedals();
        BikeRotate();


        
    }

    private void FixedUpdate()
    {

        LeanBike();
    }

    private void LateUpdate()
    {
       
    }

    private void MovePedals()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A was pressed");
            rb.AddForce(Vector3.forward * bikeSpeed);
            float x = Input.GetAxis("Horizontal") * 15f;
            Vector3 euler = transform.localEulerAngles;
            euler.z = Mathf.Lerp(euler.x, x, leanSpeed * Time.deltaTime);
            transform.localEulerAngles = euler;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D was pressed");
            rb.AddForce(Vector3.forward * bikeSpeed);
            float z = Input.GetAxis("Horizontal") * 90f;
            Vector3 euler = transform.localEulerAngles;
            euler.z = Mathf.Lerp(euler.z, z, leanSpeed * Time.deltaTime);
        }
    }

    private void BikeRotate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K was pressed");
           
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L was pressed");
           
        }
    }

    private void PivotTo(Vector3 position)
    {
        Vector3 offset = transform.position - position;
        foreach(Transform child in transform)
        {
            child.transform.position += offset;
            transform.position = position;
        }
    }

    private void LeanBike()
    {
        PivotTo(eulAngles);
    }

}
    

