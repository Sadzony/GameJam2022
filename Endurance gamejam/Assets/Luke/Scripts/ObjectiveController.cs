using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    GameObject[] deliverableHouses;

    [HideInInspector]
    public DeliverableHouse deliverableHouse;

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
        deliverableHouse = deliverableHouses[Random.Range(0, deliverableHouses.Length)].GetComponent<DeliverableHouse>();
    }
}
