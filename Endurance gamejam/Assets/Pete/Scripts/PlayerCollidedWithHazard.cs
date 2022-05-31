using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidedWithHazard : MonoBehaviour
{
    [SerializeField]
    private float knockbackValue = 100;
    [SerializeField]
    private ParticleSystem collidedFX;

    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Player") 
            {
                other.gameObject.GetComponent<BikeAcceleration>().stop = true;
                other.transform.GetChild(0).GetComponent<BikeSteering>().enabled = false;
                other.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, knockbackValue), Random.Range(0, knockbackValue), Random.Range(0, -knockbackValue)), ForceMode.Impulse);
                collidedFX.Play();
        }
    }

} // class
