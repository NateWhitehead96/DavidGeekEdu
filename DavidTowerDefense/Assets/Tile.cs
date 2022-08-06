using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied; // true or false to know if this tile is occupied
    public SpriteRenderer sprite; // to help change the color of the tile
    public Color unoccupiedColor;
    public Color occupiedColor; // the color the tile changes to when a tower is placed

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = unoccupiedColor; // assign the color
    }

    private void Update()
    {
        if(isOccupied == true)
        {
            sprite.color = occupiedColor; // switch color when tower is placed
        }
    }
}
