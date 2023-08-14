using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : MonoBehaviour
{

    WaterSpawner ws;

    void Start()
    {
        ws = GameObject.FindObjectOfType<WaterSpawner>();
    }

    void OnTriggerEnter(Collider other) {
        ws.SpawnWater();
        Destroy(gameObject, 2);
    }

}
