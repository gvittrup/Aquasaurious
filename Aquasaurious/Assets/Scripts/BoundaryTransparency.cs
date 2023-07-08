using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTransparency : MonoBehaviour
{
    public Transform player;
    public GameObject wall;
    Transform boundary;
    Renderer renderer;
    Color color;
    float value;

    void Start() {
        renderer = wall.GetComponent<Renderer>();
        boundary = GetComponent<Transform>();

        color = renderer.material.color;
        color.a = 0.0f;

        renderer.material.color = color;
    }

    private void OnTriggerStay(Collider collider) {
        if(wall.tag == "X-Axis")
            value = (player.position.x - boundary.position.x) / (wall.transform.position.x - boundary.position.x);
        else value = (player.position.y - boundary.position.y) / (wall.transform.position.y - boundary.position.y);
        
        color.a = Mathf.Lerp(0.0f, 1.0f, value);
        renderer.material.color = color;
    }

}
