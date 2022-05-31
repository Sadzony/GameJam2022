using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{

    private BoxCollider _collider;
    [SerializeField]
    private GameObject[] Hazards;
    private float SpawnPercentage = 10;
    private GameObject DifficultyManager;

    private void Awake() 
    {
        if (!DifficultyManager) { DifficultyManager = GameObject.Find("DifficultyManagerDONTRENAME"); }
        if (!_collider) { _collider = GetComponent<BoxCollider>(); }
    }

    private void Start()  
    {   
        SpawnPercentage += DifficultyManager.GetComponent<DifficultyManager>().GetNewSpawnRate(); 

        if (Random.Range(0, 99) < SpawnPercentage) { Instantiate(Hazards[Random.Range(0, Hazards.Length)], RandomPointInBox(), new Quaternion(0, 0, 0, 0)); }
    }
    private Vector3 RandomPointInBox() { return _collider.bounds.center + new Vector3((Random.value - 0.5f) * (_collider.bounds.size.x - 10 ), (Random.value - 0.5f) * _collider.bounds.size.y, (Random.value - 0.5f) * _collider.bounds.size.z); }
} // class
