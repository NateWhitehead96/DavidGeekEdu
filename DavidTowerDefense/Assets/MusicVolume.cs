using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    public AudioSource source; // the sound effect or music
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>(); // find the audio source on the gameobject and set it to this variable
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = SoundEffects.instance.volume; // set the volume accordingly
    }
}
