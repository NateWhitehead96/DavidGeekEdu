using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene"); // load the game scene
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // load the main menu
    }
}
