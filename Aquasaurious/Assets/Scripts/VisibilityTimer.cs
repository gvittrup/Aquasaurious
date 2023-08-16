using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityTimer : MonoBehaviour
{

    Color color;

    void Start()
    {
        color = GetComponent<Renderer>().material.color;
        StartCoroutine(Timer(5.0f, 0.05f));
    }

    IEnumerator Timer(float time, float intervalTime)
    {
        float elapsedTime = 0f;
        int index = 0;
        while(elapsedTime < time)
        {

            if(color.a < 0.0f) break;

            color.a = 1.0f - elapsedTime;
            GetComponent<Renderer>().material.color = color;

            elapsedTime += Time.deltaTime;
            index++;

            yield return new WaitForSecondsRealtime(intervalTime);
        }
        Destroy(gameObject);   
    }

}
