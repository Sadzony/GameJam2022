using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    private NewspaperCannon cannon;
    private Vector3 objectivePos;
    private Vector3 distToObjective;
    private void Start()
    {
        cannon = FindObjectOfType<NewspaperCannon>();
        distToObjective = Vector3.zero;
    }
    private void Update()
    {
        distToObjective = objectivePos - transform.position;
        if(distToObjective.magnitude > cannon.range)
        {
            // We have missed the target.
            Destroy(this);

            Debug.Log("Newspaper Missed. Killing");
        }
    }
    private void OnDestroy()
    {
        cannon.Reload();
    }

    public void SetTarget(Vector3 target)
    {
        objectivePos = target;
    }
}
