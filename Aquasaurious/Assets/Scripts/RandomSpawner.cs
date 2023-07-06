using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject cubePrefab;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    // public float speed = 1;

    void Start()
    {
        InvokeRepeating("SpawnObject",spawnTime,spawnDelay);
    }
    

    public void SpawnObject() {
        Vector3 randomSpawnPosition = new Vector3(0,Random.Range(-10,11),0);
        Instantiate(cubePrefab,randomSpawnPosition,Quaternion.identity);
        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }

}
