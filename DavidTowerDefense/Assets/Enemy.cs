using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Checkpoints checkpoints; // access to all of the checkpoint
    public int moveSpeed; // how fast the enemy can move
    public int health; // how many hits they can take
    public int currentPoint; // what checkpoint they are currently moving to
    public Slider healthBar; // access to the floating health bar
    public Animator anim; // link to our animation controller
    public bool dying; // help us know when the enemy dies
    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectOfType<Checkpoints>(); // when the enemy spawns, they will find the checkpoints and know how to walk
        healthBar.maxValue = health; // set the new max value
        FindObjectOfType<EnemySpawner>().remainingEnemies++; // add to how many enemies are alive
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;// constantly update the slider value to be our health
        // move the enemy to the current point it wants to go to
        transform.position = Vector3.MoveTowards(transform.position, checkpoints.points[currentPoint].position, moveSpeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, checkpoints.points[currentPoint].position); // find the distance to its current point
        if(distance <= 0.1f) // if we're close enough to the checkpoint
        {
            currentPoint++; // set our current point to be +1
        }

        if(health <= 0 && dying == false)
        {
            StartCoroutine(EnemyDying());
            FindObjectOfType<EnemySpawner>().remainingEnemies--;
        }

        if(currentPoint >= checkpoints.points.Length) // when the enemy hits the last point
        {
            FindObjectOfType<LoseCondition>().lives--; // lose 1 life
            FindObjectOfType<EnemySpawner>().remainingEnemies--;
            Destroy(gameObject); // destroy the enemy
        }
    }

    IEnumerator EnemyDying()
    {
        dying = true;
        FindObjectOfType<GameManager>().gold += 5; // award player with gold
        SoundEffects.instance.enemyDie.Play(); // play the enemy dying sound
        anim.SetBool("dying", true); // play the dying animation
        GetComponent<BoxCollider2D>().enabled = false; // disable any collider on the enemy
        moveSpeed = 0; // stop the movement
        yield return new WaitForSeconds(0.5f); // time it waits before dying
        Destroy(gameObject); // destroy enemy
    }
}
