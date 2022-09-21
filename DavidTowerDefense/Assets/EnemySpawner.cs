using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyToSpawn; // what enemy we want to spawn
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
            if(wave < 4) // any wave before wave 4 will spawn our fist enemy type
            {
                Instantiate(EnemyToSpawn[0], transform.position, transform.rotation); // spawn enemy
            }
            if(wave > 3 && wave < 6) // spawn the 2nd enemy type from wave 4 - 5
            {
                Instantiate(EnemyToSpawn[1], transform.position, transform.rotation); // spawn enemy
            }
            if(wave > 5)
            {
                int randomEnemy = Random.Range(0, EnemyToSpawn.Length); // find a random enemy to spawn
                Instantiate(EnemyToSpawn[randomEnemy], transform.position, transform.rotation); // spawn new random enemy
            }
            timer = 0; // reset timer
            if(numberOfEnemiesToSpawn == 0) // spawned all of the enemies
            {
                StartCoroutine(StartNextWave()); // start a new wave
            }
        }
        timer += Time.deltaTime; // count up time
    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(10);
        wave++; // wave number goes up by 1
        numberOfEnemiesToSpawn += wave * 5; // increase enemies by 5 every new wave, wave 1 = 5, wave 2 = 10, etc
        SoundEffects.instance.newWave.Play(); // play new wave sound
        if(wave > 25)
        {
            numberOfEnemiesToSpawn = 0; // we've won no more enemies need to spawn
            if(remainingEnemies <= 0) // if we have killed every enemy
            {
                SceneManager.LoadScene("WinScreen"); // only load this scene
            }
        }
    }
}
