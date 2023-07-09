using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner gs;

    void Start()
    {
        gs = GameObject.FindObjectOfType<GroundSpawner>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Hello!");
        gs.SpawnTile();
        Destroy(gameObject, 2);
    }

}
