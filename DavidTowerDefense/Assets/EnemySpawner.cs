using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyToSpawn; // what enemy we want to spawn
    public float timer; // how fast we spawn enemies

    public int numberOfEnemiesToSpawn; // how many enemies we spawn
    public int remainingEnemies; // how many are alive
    public int wave; // what wave we're on
    // Start is called before the first frame update
    void Start()
    {
        wave = 1; // make sure we start on wave 1
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1 && numberOfEnemiesToSpawn > 0)
        {
            numberOfEnemiesToSpawn--; // subtract from the number of enemies for the wave
            Instantiate(EnemyToSpawn, transform.position, transform.rotation); // spawn enemy
            timer = 0; // reset timer
            if(numberOfEnemiesToSpawn == 0) // spawned all of the enemies
            {
                StartCoroutine(StartNextWave()); // start a new wave
            }
        }
        timer += Time.deltaTime; // count up time
        // Eventually we'll have waves and only spawn certain enemies on a wave
    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(10);
        wave++; // wave number goes up by 1
        numberOfEnemiesToSpawn += wave * 5; // increase enemies by 5 every new wave, wave 1 = 5, wave 2 = 10, etc
    }
}
