using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    private float DifficultyIncreaseInterval = 30.0f;
    [SerializeField]
    private float SpawnRateIncase = 10.0f;
    private float NewDiff;

    private void Awake() { StartCoroutine(DifficultyTimer()); }

    IEnumerator DifficultyTimer() 
    {
        yield return new WaitForSeconds(DifficultyIncreaseInterval);
        NewDiff += SpawnRateIncase;
        if (SpawnRateIncase != 100) { StartCoroutine(DifficultyTimer()); }
    }

    public float GetNewSpawnRate() { return NewDiff; }

} // class
