using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointer : MonoBehaviour
{
    ObjectiveController controller;
    Vector3 offsetHousePos;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<ObjectiveController>();
    }

    // Update is called once per frame
    void Update()
    {
        offsetHousePos = controller.deliverableHouse.transform.position;
        offsetHousePos.y = controller.deliverableHouse.GetComponent<BoxCollider>().bounds.size.y / 2;
        transform.LookAt(offsetHousePos);
    }
}
