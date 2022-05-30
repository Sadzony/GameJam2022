using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidedWithHazard : MonoBehaviour
{
    [SerializeField]
    private SphereCollider colliderr;
    private bool canGetKnockedback = false;
    [SerializeField]
    private float knockbackValue = 100;

    private void Awake() { StartCoroutine(timer()); }


    private void OnTriggerEnter(Collider other)
    {
        if (canGetKnockedback) 
        {
            if (other.tag == "Player") { other.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(Random.Range(0, knockbackValue), Random.Range(0, knockbackValue), Random.Range(0, knockbackValue)), other.gameObject.transform.position);  }
        }
    }

    IEnumerator timer()
    { 
        yield return new WaitForSeconds(1);
        colliderr.radius = 2;
        canGetKnockedback = true;
    }

} // class
