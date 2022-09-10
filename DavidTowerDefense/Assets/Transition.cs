using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator anim; // animation controller

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // link animator
    }

    public void MoveToScene(int levelToLoad)
    {
        StartCoroutine(Fade(levelToLoad)); // start a coroutine to fade to the level to load
    }

    IEnumerator Fade(int level)
    {
        anim.SetBool("fade", true); // starts the fade out
        //anim.Play("NameOfTheAnimation"); // to play the animation if we only have 1
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(level); // load the new level
    }
}
