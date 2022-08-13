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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnGunner(GameObject Gunner)
    {
        if(PathFinder2.done)
        {
            GameObject TowerHighlight = Gunner;
            TowerHighlight.GetComponent<TowerHighlight>().tilesParent = this.tilesParent;
            TowerHighlight.GetComponent<TowerHighlight>().camera = this.camera;
            Instantiate(TowerHighlight);
        }
        
    }

    public void SpawnMinigun(GameObject Minigun)
    {

    }

    public void SpawnArtillery(GameObject Artillery)
    {

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
