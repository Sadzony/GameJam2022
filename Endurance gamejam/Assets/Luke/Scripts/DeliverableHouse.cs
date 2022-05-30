using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverableHouse : MonoBehaviour
{
    [HideInInspector]
    public bool delivered;
    private ObjectiveController objectiveController;
    private ScoreController scoreController;
    private void Start()
    {
        objectiveController = FindObjectOfType<ObjectiveController>();
        scoreController = FindObjectOfType<ScoreController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Newspaper") && objectiveController.deliverableHouse == this)
        {
            delivered = true;
            Destroy(other.gameObject);
            scoreController.NewspaperDelivered();
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
