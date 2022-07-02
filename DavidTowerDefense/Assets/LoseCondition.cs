using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // give us access to loading scenes

public class LoseCondition : MonoBehaviour
{
    public int lives; // how many enemies can get to the end before we lose
    public GameObject losePanel; // the panel that has our restart button and text

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        losePanel.SetActive(false); // we dont want to see the lose panel on start
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 0)
        {
            losePanel.SetActive(true); // show the panel
            Time.timeScale = 0; // pause time when the lose panel come up
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0); // loading our play scene, this number might change after we make a main menu/other maps
    }
}
