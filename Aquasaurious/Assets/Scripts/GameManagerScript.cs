using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI, startUI, instructionUI, optionsUI, scoreUI, player;
    private PlayerMovement pm;

    void Start() {
        pm = player.GetComponent<PlayerMovement>();
        player.SetActive(false);
        pm.ToggleSwim(false);

        startUI.SetActive(true);
        scoreUI.SetActive(false);
    }

    public void play() {
        startUI.SetActive(false);
        instructionUI.SetActive(true);
        pm.ToggleSwim(true);
        player.SetActive(true);
    }

    public void options() {
        startUI.SetActive(false);
        optionsUI.SetActive(true);
    }

    //Enables game over canvas
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    //Handles restart button
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Handles main menu button
    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    //Handles quit button
    public void quit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
