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
        //SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        FindObjectOfType<Transition>().MoveToScene(0); // transition us to main menu
    }
}
