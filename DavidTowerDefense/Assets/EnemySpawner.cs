using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyToSpawn; // what enemy we want to spawn
    public float timer; // how fast we spawn enemies
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1)
        {
            Instantiate(EnemyToSpawn, transform.position, transform.rotation); // spawn enemy
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // count up time
        // Eventually we'll have waves and only spawn certain enemies on a wave
    }
}
