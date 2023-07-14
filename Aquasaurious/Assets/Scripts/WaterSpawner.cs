using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject tile;
    private Vector3 nextSpawnPoint;
    private float speed = 5.0f;
    private Rigidbody rb;
    private bool start = true;
    private GameObject temp;
    public Vector3 spawnpoint;

    void Start() {
        for(int i = 0; i < 4; i++) {
            SpawnWater();
        }
        start = false;
    }

    void Update() {
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        spawnpoint = nextSpawnPoint;
    }

    public void SpawnWater() {

        if(start)
            temp = Instantiate(tile, new Vector3(nextSpawnPoint.x, 10.5f, nextSpawnPoint.z), Quaternion.identity);
        else temp = Instantiate(tile, new Vector3(nextSpawnPoint.x - 0.1f, 10.5f, nextSpawnPoint.z), Quaternion.identity);

        rb = temp.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-speed, 0, 0);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }
}
