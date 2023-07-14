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
        Debug.Log("Colliding");
        gs.SpawnGround();
        Destroy(gameObject, 2);
    }

}
