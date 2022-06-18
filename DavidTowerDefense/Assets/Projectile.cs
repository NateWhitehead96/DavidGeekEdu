using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target; // the enemy the projectile will move towards
    public float moveSpeed; // how fast the projectile moves
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
            collision.gameObject.GetComponent<Enemy>().health--; // decrease the health of the enemy
            Destroy(gameObject); // destroy projectile
        }
    }
}
