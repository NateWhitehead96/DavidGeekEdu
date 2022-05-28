using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold; // our games currancy
    // building variables
    public Building towerToPlace; // the tower we want to place
    public CustomCursor customCursor; // access to the custom cursor to show and hide it
    public Tile[] tiles; // list/array of all of our tiles
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // hide the custom cursor
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && towerToPlace != null) // left click, and we have a tower on our mouse
        {
            Tile nearestTile = null; // the closest tile to our mouse
            float nearestDistance = float.MaxValue; // this will calculate the nearest distance of a tile
            foreach (Tile tile in tiles) // loop through all of the tiles in our grid
            {
                // find the distance between the tile and our mouse position
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(distance < nearestDistance) // if the mouse is over a tile
                {
                    nearestDistance = distance; // nearest distance is now that close tile
                    nearestTile = tile; // nearest tile is now that tile we're moused over
                }
            }
            if(nearestTile.isOccupied == false) // if the tile doesnt have a tower
            {
                Building newTower = Instantiate(towerToPlace, nearestTile.transform.position, transform.rotation); // build our new tower
                newTower.tile = nearestTile; // set the tile of the tower to the tile we place the tower on
                towerToPlace = null; // reset the tower to place
                nearestTile.isOccupied = true; // make the tile occupied
                Cursor.visible = true; // bring our defualt cursor back
                customCursor.gameObject.SetActive(false); // hide the custom cursor
            }
        }
    }

    // Buying tower function for a button press
    public void BuyTower(Building tower)
    {
        if(gold >= tower.cost)
        {
            customCursor.gameObject.SetActive(true); // makes the cursor visible
            // set the cursor image to be the same as the tower
            customCursor.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false; // hides the arrow pointer cursor
            towerToPlace = tower; // set the tower to place to be this tower we're buying
        }
    }
}
