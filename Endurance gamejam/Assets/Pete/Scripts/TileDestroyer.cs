using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
    private Quaternion startRotation;
    private PersonExplode personExploder;
    private void Start()
    {
        startRotation = transform.rotation;
        personExploder = FindObjectOfType<PersonExplode>();
    }
    private void Update()
    {
        if (personExploder.exploded)
        {
            Destroy(this);
        }
        transform.rotation = startRotation;
    }
    private void OnTriggerEnter(Collider other) { Destroy(other.gameObject); }

} // class
