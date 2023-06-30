using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionOverlay : MonoBehaviour
{

    public GameObject Screen;
    public TextMeshProUGUI timer;
    private int frameCount = 0;
    private int timerCount = 6;
    private bool flag = false;

    void Start()
    {
        if(!flag) {
            Screen.SetActive(true);
            flag = true;
        }
    }

    void FixedUpdate()
    {
        if(frameCount % 50 == 0)
            timerCount--;

        if(frameCount / 50 == 5)
            Screen.SetActive(false);

        timer.SetText(timerCount.ToString());
        frameCount++;
    }
}
