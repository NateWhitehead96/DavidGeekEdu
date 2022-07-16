using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Checkpoints checkpoints; // access to all of the checkpoint
    public int moveSpeed; // how fast the enemy can move
    public int health; // how many hits they can take
    public int currentPoint; // what checkpoint they are currently moving to
    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectOfType<Checkpoints>(); // when the enemy spawns, they will find the checkpoints and know how to walk
    }

    // Update is called once per frame
    void Update()
    {
        // move the enemy to the current point it wants to go to
        transform.position = Vector3.MoveTowards(transform.position, checkpoints.points[currentPoint].position, moveSpeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, checkpoints.points[currentPoint].position); // find the distance to its current point
        if(distance <= 0.1f) // if we're close enough to the checkpoint
        {
            currentPoint++; // set our current point to be +1
        }

        if(health <= 0)
        {
            FindObjectOfType<GameManager>().gold += 5; // award player with gold
            SoundEffects.instance.enemyDie.Play(); // play the enemy dying sound
            Destroy(gameObject); // destroy enemy
        }

        if(currentPoint >= checkpoints.points.Length) // when the enemy hits the last point
        {
            FindObjectOfType<LoseCondition>().lives--; // lose 1 life
            Destroy(gameObject); // destroy the enemy
        }
    }
}
