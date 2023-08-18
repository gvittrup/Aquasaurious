using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;

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
        Application.Quit();
    }
}
