using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperCannon : MonoBehaviour
{
    public GameObject newspaperPrefab;
    public Transform cannonMuzzle;
    public ParticleSystem cannonFireFX;
    public float range;

    private ObjectiveController objectiveController;
    private ObjectivePointer objectivePointer;
    private PersonExplode personExploder;
    private ParticleSystem cannonFireInstance;
    private Rigidbody playerRB;
    private bool fired;

    private void Start()
    {
        objectiveController = FindObjectOfType<ObjectiveController>();
        objectivePointer = GetComponent<ObjectivePointer>();
        personExploder = GetComponentInParent<PersonExplode>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        fired = false;
    }

    private void Update()
    {
        Vector3 housePosition = objectiveController.deliverableHouse.gameObject.transform.position;

        if (personExploder.exploded)
        {
            objectivePointer.enabled = false;
            return;
        }

        if (!fired)
        {
            housePosition.y = objectiveController.deliverableHouse.GetComponent<BoxCollider>().bounds.size.y / 2;
            Vector3 dist = housePosition - transform.position;
            float overrideForce = 1.25f;

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
        cannonFireInstance = Instantiate(cannonFireFX);
        cannonFireInstance.transform.position = cannonMuzzle.transform.position;
        cannonFireInstance.transform.parent = cannonMuzzle.transform;
        cannonFireInstance.transform.Rotate(new Vector3(90, 0, 0));
        cannonFireInstance.Play();

        // Shoot the actual newspaper.
        Vector3 toHouse = housePos - transform.position;
        GameObject newspaper = Instantiate(newspaperPrefab);

        newspaper.transform.position = cannonMuzzle.position;
        Rigidbody rb = newspaper.GetComponent<Rigidbody>();

        Newspaper newpaperScript = newspaper.GetComponent<Newspaper>();
        newpaperScript.SetTarget(housePos);

        rb.AddForce(toHouse * force);
    }
}
