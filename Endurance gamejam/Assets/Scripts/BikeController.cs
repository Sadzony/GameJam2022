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
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D was pressed");
            rb.AddForce(Vector3.forward * bikeSpeed);
        }
    }

    private void BikeRotate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K was pressed");
            rb.AddForce(Vector3.right);
            PivotTo(-eulAngles);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L was pressed");
            PivotTo(Vector3.left);
        }

    }

    private void PivotTo(Vector3 position)
    {
        Vector3 offset = transform.position - position;
        foreach(Transform child in transform)
        {
            child.transform.position += offset * leanSpeed * Time.deltaTime;
            transform.position = position;
        }
    }

    private void LeanBike()
    {
        
    }

}
    

