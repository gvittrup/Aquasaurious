using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject tile;
    private Vector3 nextSpawnPoint;
    private float speed = 5.0f;
    private Rigidbody rb;

    void Start() {
        for(int i = 0; i < 15; i++) {
            SpawnTile();
        }
    }

    void Update() {

    }

    public void SpawnTile() {
        GameObject temp = Instantiate(tile, nextSpawnPoint, Quaternion.identity);
        rb = temp.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-speed, 0, 0);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}
