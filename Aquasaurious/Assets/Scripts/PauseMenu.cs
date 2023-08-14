using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    private bool gameIsPaused = false;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gameIsPaused == false) { 
                Pause();
            } else if (optionsMenu.activeSelf == false){  
                Resume();
            } 
        }

    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

}
