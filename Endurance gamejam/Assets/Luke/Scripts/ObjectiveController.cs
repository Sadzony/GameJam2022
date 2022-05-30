using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    GameObject[] deliverableHouses;

    public GameObject deliverableHouse;

    // Start is called before the first frame update
    void Start()
    {
        deliverableHouses = GameObject.FindGameObjectsWithTag("DeliverableHouse");
        GenerateObjective();
    }

    public void GenerateObjective()
    {
        deliverableHouse = deliverableHouses[Random.Range(0, deliverableHouses.Length)];
    }
}
