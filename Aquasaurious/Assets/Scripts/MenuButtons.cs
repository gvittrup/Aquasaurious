using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuButtons : MonoBehaviour
{

    public void StartButton() {

        SceneManager.LoadScene("Level Scene");

    }

    public void ExitButton() {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif

    }

    public void BackButton() {
        SceneManager.LoadScene("Main Menu");
    }

}
