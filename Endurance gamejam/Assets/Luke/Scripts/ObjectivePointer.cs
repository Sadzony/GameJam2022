using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointer : MonoBehaviour
{
    ObjectiveController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<ObjectiveController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(controller.deliverableHouse.transform);
    }
}
