using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // allows us to move between scenes

public class MenuButtons : MonoBehaviour
{
    // we can load scenes using either the name of the scene, or its build index
    // for example loading our play scene will be build index 1 or "SampleScene" (the name of the scene can be changed)
    public void PlayGame() // load our play scene
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings() // load the settings scene
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame() // quit our game, only works if the game is built not in unity engine
    {
        Application.Quit();
    }
}
