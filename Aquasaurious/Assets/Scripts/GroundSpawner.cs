using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject tile;
    private Vector3 nextSpawnPoint;
    private float speed = 5.0f;
    private Rigidbody rb;
    private bool start = true;
    private GameObject temp;

    void Start() {
        for(int i = 0; i < 4; i++) {
            SpawnGround();
        }
        start = false;
    }

    void Update() {
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    public void SpawnGround() {

        if(start)
            temp = Instantiate(tile, new Vector3(nextSpawnPoint.x - 50.0f, -10.5f, nextSpawnPoint.z), Quaternion.identity);
        else temp = Instantiate(tile, new Vector3(nextSpawnPoint.x - 0.1f, -10.5f, nextSpawnPoint.z), Quaternion.identity);
        
        rb = temp.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-speed, 0, 0);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }
}
