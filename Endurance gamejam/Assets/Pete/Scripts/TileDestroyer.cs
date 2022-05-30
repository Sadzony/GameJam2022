using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
    private Quaternion startRotation;
    private void Start()
    {
        startRotation = transform.rotation;
    }
    private void Update()
    {
        transform.rotation = startRotation;
    }
    private void OnTriggerEnter(Collider other) { Destroy(other.gameObject); }

} // class
