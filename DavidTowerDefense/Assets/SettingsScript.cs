using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access to any UI class
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public Slider volumeSlider; // volume slider
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundEffects.instance.volume = volumeSlider.value; // setting the volume of all things
    }

    public void ReturnToMenu() // button function to return to main menu
    {
        SceneManager.LoadScene("MainMenu");
    }
}
