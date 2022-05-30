using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverableHouse : MonoBehaviour
{
    [HideInInspector]
    public bool delivered;
    private ObjectiveController objectiveController;
    private void Start()
    {
        objectiveController = FindObjectOfType<ObjectiveController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Newspaper") && objectiveController.deliverableHouse == this)
        {
            delivered = true;
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        if(objectiveController.deliverableHouse == this)
        {
            objectiveController.GenerateObjective();
        }
    }
}
