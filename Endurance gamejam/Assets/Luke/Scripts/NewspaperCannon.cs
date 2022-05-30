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

            Vector3 origin = transform.position;
            origin.y += 10;

            Ray ray = new Ray(origin, dist);
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Debug.Log("House pos: " + housePosition);
                if (!fired)
                {
                    Vector3 hitPos = hit.collider.gameObject.transform.position;

                    Debug.Log("Clean shot?: " + (hitPos == housePosition));
                    if(!(hitPos == housePosition))
                    {
                        Debug.Log("Reason: " + hit.collider.gameObject.name + " Blocking.");
                    }

                    Debug.Log("In Range?: " + (dist.magnitude < range));

                    if (dist.magnitude < range && hitPos == housePosition)
                    {
                        FireAtObjectiveHouse(housePosition, dist.magnitude * overrideForce);
                        fired = true;
                        Debug.Log("Fire");
                    }
                }
            }
        }
    }

    public void Reload()
    {
        fired = false;
        Debug.Log("Reloaded");
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
