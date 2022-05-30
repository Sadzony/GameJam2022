using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidedWithHazard : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(100000, gameObject.transform.position, 1000); }
    }


} // class
