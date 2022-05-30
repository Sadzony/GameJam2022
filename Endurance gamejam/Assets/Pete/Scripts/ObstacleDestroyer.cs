using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private void Start() { GameObject.Destroy(this, 2); }

    private void OnTriggerStay(Collider other) { if (other.tag == "Player") { GameObject.Destroy(gameObject); } }

}// class
