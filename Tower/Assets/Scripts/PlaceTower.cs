using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    //public GameObject Gunner;

    // Start is called before the first frame update

    public Camera camera;
    public GameObject tilesParent;
    GameObject TowerHighlight;
    float minDistanceMouse = 1.9f;
    Transform objectHit;
    
    public void SpawnTower(GameObject Tower)
    {
        GameObject TowerHighlight = Tower;
        TowerHighlight.GetComponent<TowerHighlight>().tilesParent = this.tilesParent;
        TowerHighlight.GetComponent<TowerHighlight>().camera = this.camera;
        Instantiate(TowerHighlight);
        
    }
    public void DestroyTile(GameObject Tile)
    {
        if(!GameController.start)
        {
            GameObject TowerHighlight = Tile;
            TowerHighlight.GetComponent<DestroyTile>().tilesParent = this.tilesParent;
            TowerHighlight.GetComponent<DestroyTile>().camera = this.camera;
            Instantiate(TowerHighlight);
        }
    }
    
    
}
