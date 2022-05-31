using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    GameObject[] deliverableHouses;

    [HideInInspector]
    public DeliverableHouse deliverableHouse;

    private DeliverableHouse prevDeliverableHouse;

    // Start is called before the first frame update
    void Start()
    {
        deliverableHouses = GameObject.FindGameObjectsWithTag("DeliverableHouse");
        GenerateObjective();
    }

    private void Update()
    {
        if (deliverableHouse)
        {
            if (deliverableHouse.delivered)
            {
                deliverableHouse.delivered = false;
                GenerateObjective();
            }
        }
    }

    public void GenerateObjective()
    {
        deliverableHouses = GameObject.FindGameObjectsWithTag("DeliverableHouse");
        if(deliverableHouses.Length > 0)
        {
            while (deliverableHouse == prevDeliverableHouse)
            {
                deliverableHouse = deliverableHouses[Random.Range(0, deliverableHouses.Length)].GetComponent<DeliverableHouse>();
            }
            prevDeliverableHouse = deliverableHouse;
        }
    }
}
