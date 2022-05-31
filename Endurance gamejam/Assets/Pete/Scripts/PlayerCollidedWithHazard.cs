using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidedWithHazard : MonoBehaviour
{
    [SerializeField]
    private float knockbackValue = 100;
    [SerializeField]
    private GameObject collidedFX;
    private bool doOnce = false;
    AudioSource explosionAudio;
    private void Awake()
    {
        explosionAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Player" && !doOnce) 
            {
                other.gameObject.GetComponent<BikeAcceleration>().stop = true;
                other.transform.GetChild(0).GetComponent<BikeSteering>().enabled = false;
                other.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(knockbackValue / 2, knockbackValue), Random.Range(knockbackValue / 2, knockbackValue), Random.Range(knockbackValue / 2, -knockbackValue)), ForceMode.Impulse);
                GameObject temp = Instantiate(collidedFX, gameObject.transform);
                explosionAudio.Play();
                temp.transform.localScale = new Vector3(5, 5, 5);
                doOnce = true;
        }
    }

} // class
