using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperCannon : MonoBehaviour
{
    public GameObject newspaperPrefab;
    public GameObject right;

    public void Fire(Vector3 origin, float inclination, float force)
    {
        Vector3 housePosition = FindObjectOfType<ObjectiveController>().deliverableHouse.gameObject.transform.position;
        Vector3 toHouse = housePosition - transform.position;
        GameObject newspaper = Instantiate(newspaperPrefab);

        Vector3 dynRight = Vector3.Cross(transform.up, transform.forward);
        dynRight.Normalize();
        Vector3 fullDir = new Vector3(1, inclination, 0);

        float dot = Vector3.Dot(transform.right, toHouse);
        Debug.Log("Dot: " + dot);

        Vector3 toRight = transform.position - right.transform.position;

        Debug.Log("Right: " + transform.right.x);

        if (dot > 0)
        {
            Debug.Log("Right");
            fullDir.x = -toRight.x;
        }
        else
        {
            Debug.Log("Left");
            fullDir.x = toRight.x;
        }

        newspaper.transform.position = origin;
        Rigidbody rb = newspaper.GetComponent<Rigidbody>();
        rb.AddForce(fullDir * force);
    }
}
