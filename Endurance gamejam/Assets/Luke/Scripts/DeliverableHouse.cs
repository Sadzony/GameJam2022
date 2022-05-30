using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverableHouse : MonoBehaviour
{
    BoxCollider trigger;

    [HideInInspector]
    public bool delivered;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Newspaper"))
        {
            Debug.Log("Delivered Newspaper");
            delivered = true;
        }
    }
}
