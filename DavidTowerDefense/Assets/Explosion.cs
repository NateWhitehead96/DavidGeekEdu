using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float timer; // how long the explosion will live
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1) // after a second destroy it
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }
}
