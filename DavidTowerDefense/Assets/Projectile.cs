using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type // it knows what type of projectile this will be
{
    Arrow,
    Cannon
}

public class Projectile : MonoBehaviour
{
    public Transform target; // the enemy the projectile will move towards
    public float moveSpeed; // how fast the projectile moves
    public Type type; // what type of projectile it is

    public LayerMask layer; // to help with aoe projectiles, its the layer all enemies share

    public GameObject explosion; // explosion effect we want to play
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) // the target is either dead or not there any more, destroy the projectile
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // move projectile
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            if (type == Type.Cannon) // how our cannon collides
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(collision.transform.position, 2, layer); // create a circle around the enemy
                for (int i = 0; i < enemies.Length; i++) // loop through all enemies in blast radius
                {
                    enemies[i].GetComponent<Enemy>().health--; // subtract health
                }
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (type == Type.Arrow) // how our arrow tower collides
            {
                collision.gameObject.GetComponent<Enemy>().health--; // decrease the health of the enemy
                Destroy(gameObject); // destroy projectile
            }
        }
    }
}
