using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects instance; // an instance or a single version of this script
    private void Awake()
    {
        if(instance != null) // if there is already a version of the sound effects
        {
            Destroy(gameObject); // destroy the new version trying to come in
        }
        else // there is no sound effect manager yet
        {
            instance = this; // the instance will be this game object
            DontDestroyOnLoad(gameObject); // dont destroy game object between levels
        }
    }

    public AudioSource enemyDie;
    public AudioSource shootSound;
    public float volume; // the volume of the things
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyDie.volume = volume;
        shootSound.volume = volume;
    }
}
