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
        // player.transform.position = new Vector3(0f, 0f, 0f);
        pm.ToggleSwim(true);
        ps.SetScore(0);
        pm.isDead = false;
        pm.health = 1.0f;
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
