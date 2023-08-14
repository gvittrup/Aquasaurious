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

    int[] zValues = new int[] {-25, -15, 0, 0, 20};

    void Start()
    {
        InvokeRepeating("SpawnObject",spawnTime,spawnDelay);
    }
    

    public void SpawnObject() {

        Vector3 randomSpawnPosition = new Vector3(50, Random.Range(-10,11),0);
        Instantiate(fish,randomSpawnPosition,Quaternion.identity);

        //Handles spawning of atmosphere elements, such as bottles and coral
        int randomObject = Random.Range(0,3);
        int randomZ = Random.Range(0,5);
        if(objects[randomObject].gameObject.CompareTag("Ground")) {

            //Y Value is hard-coded AT THE MOMENT
            randomSpawnPosition = new Vector3(50, ground.transform.position.y, zValues[randomZ]);
            // randomSpawnPosition = new Vector3(50, -10.5f, zValues[randomZ]);

        } else {
            randomSpawnPosition = new Vector3(50, Random.Range(-8,8), zValues[randomZ]);
        }
        Instantiate(objects[randomObject], randomSpawnPosition, Quaternion.identity);

        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }

}
