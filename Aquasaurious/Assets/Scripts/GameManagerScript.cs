using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI, startUI, instructionUI, optionsUI, scoreUI, player;
    private PlayerMovement pm;
    private PlayerScore ps;

    void Start() {
        pm = player.GetComponent<PlayerMovement>();
        ps = player.GetComponent<PlayerScore>();

        player.SetActive(false);
        pm.ToggleSwim(false);
        pm.isDead = true;

        startUI.SetActive(true);
        scoreUI.SetActive(false);
    }

    public void play() {
        startUI.SetActive(false);
        instructionUI.SetActive(true);
        pm.ToggleSwim(true);
        player.SetActive(true);
        pm.Spawn();
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
        pm.Spawn();
        ps.SetScore(0);
        gameOverUI.SetActive(false);
    }

    //Handles main menu button
    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
