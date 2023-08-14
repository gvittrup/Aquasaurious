using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAnimation : MonoBehaviour
{

    Renderer rend;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        speed /= 3;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = (Time.fixedTime * -speed); 
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }
}
