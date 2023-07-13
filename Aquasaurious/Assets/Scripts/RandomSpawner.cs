using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject[] objects;
    public GameObject fish, ground;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    int[] zRanges = new int[] {-15, -10, 0, 15};

    void Start()
    {
        InvokeRepeating("SpawnObject",spawnTime,spawnDelay);
    }
    

    public void SpawnObject() {

        Vector3 randomSpawnPosition = new Vector3(50, Random.Range(-10,11),0);
        Instantiate(fish,randomSpawnPosition,Quaternion.identity);

        //Handles spawning of atmosphere elements, such as bottles and coral
        int randomObject = Random.Range(0,3);
        int randomZ = Random.Range(0,4);
        if(objects[randomObject].gameObject.tag == "Ground") {
            randomSpawnPosition = new Vector3(50, ground.transform.position.y, zRanges[randomZ]);
        } else {
            randomSpawnPosition = new Vector3(50, Random.Range(-8,8), zRanges[randomZ]);
        }
        Instantiate(objects[randomObject], randomSpawnPosition, Quaternion.identity);

        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }

}
