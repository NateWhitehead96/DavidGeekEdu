using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAim : MonoBehaviour
{
    public GameObject projectile; // whatever projectile/bullet it fires
    public List<GameObject> enemiesInRange; // all of the enemies near our tower

    public float reloadSpeed; // how often it shoots
    public float timer; // a counter to know when to shoot
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInRange.Count <= 0) return; // if there's no nearby enemies, dont run the rest of the code

        if(timer >= reloadSpeed) // if the timer is at our reload time
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation); // spawns the projectile
            newProjectile.GetComponent<Projectile>().target = enemiesInRange[0].transform; // set the proj to go to target
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // always count up timer

        Vector3 lookDirection = enemiesInRange[0].transform.position - transform.position; // create a direction
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; // calculate rotation
        transform.rotation = Quaternion.Euler(0, 0, angle); // set rotation
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            enemiesInRange.Add(collision.gameObject); // add the passing enemy to our list of enemies in range
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            enemiesInRange.Remove(collision.gameObject); // remove the enemy if it gets out of our range
        }
    }
}
