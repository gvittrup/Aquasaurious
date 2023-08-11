using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    public GameObject broken, instance;
    private Renderer renderer;
    private Color color;

    void Start() {
        renderer = GetComponent<Renderer>();
        color = SetRandomColor();
        renderer.material.color = color;
    }

    void OnCollisionEnter(Collision collision) {
        instance = Instantiate(broken, transform.position, transform.rotation);

        for (int i = 0; i < instance.transform.childCount; i++) {
            instance.transform.GetChild(i).GetComponent<Renderer>().material.color = color;
        }

        Destroy(gameObject);

    }

    private Color SetRandomColor() { return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1.0f); }

}
