using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    [SerializeField]
    private SphereCollider colliderr;


    private void Awake()
    {
        colliderr.radius = 10;
        GameObject.Destroy(this, 1);
    }

    private void OnTriggerStay(Collider other) { if (other.tag == "Player") { GameObject.Destroy(gameObject); } }

}// class
