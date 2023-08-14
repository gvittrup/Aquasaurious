using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFishSpawner : MonoBehaviour
{

    public GameObject killFish;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject",spawnTime,spawnDelay);
    }

    public void SpawnObject(){
        Vector3 randomSpawnPosition = new Vector3(50, Random.Range(-10,11),0);
        Instantiate(killFish,randomSpawnPosition,Quaternion.identity);
        
        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }

}
