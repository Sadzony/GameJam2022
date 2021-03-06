using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyToLoadNewLevel : MonoBehaviour
{
    private GameObject Generator;
    [SerializeField]
    private float NewTileSpawnOffset = 50.0f;

    private void Start() { 

        if (!Generator) {
            Generator = GameObject.Find("LevelGeneratorPrefabDONTCHANGENAME"); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Vector3 tempTransform;

            tempTransform = Generator.GetComponent<Transform>().position;
            tempTransform.z = tempTransform.z + NewTileSpawnOffset;
            Generator.GetComponent<Transform>().position = tempTransform;
            Generator.GetComponent<LevelGeneration>().SpawnPrefab();
            Destroy(gameObject);
        }
    }


} // class
