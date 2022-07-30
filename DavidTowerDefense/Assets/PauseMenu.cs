using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1; // make the game go back to normal speed
        gameObject.SetActive(false); // hide the pause menu
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
