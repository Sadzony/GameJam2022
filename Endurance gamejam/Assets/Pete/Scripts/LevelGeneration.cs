using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject[] SpawnPoints;
    [SerializeField]
    private GameObject[] prefabsHouses;
    [SerializeField]
    private GameObject[] prefabsGround;
    [SerializeField]
    private GameObject LevelLoader;
    private void Awake() { SpawnPrefab(); }


    public void SpawnPrefab() 
    {

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            int randomNumber = Random.Range(0, prefabsHouses.Length);
            int randomNumberGround = Random.Range(0, prefabsGround.Length);

            if (SpawnPoints[i].tag == "HouseLeft") { GameObject spawnedItem = Instantiate(prefabsHouses[randomNumber], SpawnPoints[i].GetComponent<Transform>()); spawnedItem.GetComponent<Transform>().parent = null; spawnedItem.GetComponent<Transform>().Rotate(new Vector3(0,90,0)); }
            if (SpawnPoints[i].tag == "HouseRight") { GameObject spawnedItem = Instantiate(prefabsHouses[randomNumber], SpawnPoints[i].GetComponent<Transform>()); spawnedItem.GetComponent<Transform>().parent = null; spawnedItem.GetComponent<Transform>().Rotate(new Vector3(0, -90, 0)); }
            if (SpawnPoints[i].tag == "Ground") { GameObject spawnedItem = Instantiate(prefabsGround[randomNumberGround], SpawnPoints[i].GetComponent<Transform>()); spawnedItem.GetComponent<Transform>().parent = null; }
            if (SpawnPoints[i].tag == "Loader") { GameObject spawnedItem = Instantiate(LevelLoader, SpawnPoints[i].GetComponent<Transform>()); spawnedItem.GetComponent<Transform>().parent = null; }
        }
    }

} // class
