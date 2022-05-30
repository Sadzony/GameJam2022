using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperCannon : MonoBehaviour
{
    public GameObject newspaperPrefab;
    public float range;
    private ObjectiveController objectiveController;
    private bool fired;

    private void Start()
    {
        objectiveController = FindObjectOfType<ObjectiveController>();
        fired = false;
    }

    private void Update()
    {
        Vector3 housePosition = objectiveController.deliverableHouse.gameObject.transform.position;

        if (!fired)
        {
            Vector3 dist = housePosition - transform.position;
            dist.y += 4;
            float overrideForce = 4.0f;

            Ray ray = new Ray(transform.position, dist);

            if(!Physics.Raycast(ray, out RaycastHit hit, range))
            {
                return;
            }

            if (!fired)
            {
                if (dist.magnitude < range)
                {
                    FireAtObjectiveHouse(housePosition, dist.magnitude * overrideForce);
                    fired = true;
                }
            }
        }
    }

    public void Reload()
    {
        fired = false;
    }

    private void FireAtObjectiveHouse(Vector3 housePos, float force)
    {
        Vector3 toHouse = housePos - transform.position;
        toHouse.y += 2;
        GameObject newspaper = Instantiate(newspaperPrefab);

        newspaper.transform.position = transform.position;
        Rigidbody rb = newspaper.GetComponent<Rigidbody>();

        Newspaper newpaperScript = newspaper.GetComponent<Newspaper>();
        newpaperScript.SetTarget(housePos);

        rb.AddForce(toHouse * force);
    }
}
