using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHighlight : MonoBehaviour
{
    public GameObject tilesParent;
    public int cost;
    GameObject TowerObj;
    float minDistanceMouse = 1.9f;
    Transform objectHit;
    public bool notBought = true;
    bool tile;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Temp");   
        foreach (GameObject obj in taggedObjects) 
        {
            Debug.Log("Destroyed Temps" + taggedObjects.Length);
	        Destroy(obj);
        }
        gameObject.tag = "Temp";
    }
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        //all this code only runs before you buy the tower
        if(notBought)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)) {
                objectHit = hit.transform;
                //Debug.Log("Hit Tile");
                if(hit.transform.gameObject.CompareTag("Tile"))
                {
                    Debug.Log("Hit Tile");
                    gameObject.transform.position = objectHit.transform.position;
                    tile = true;
                }
                else
                {
                    tile = false;
                }
            }
            else
            {
                tile = false;
            }

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // if left click, buy and place
            if(Input.GetMouseButtonDown(0) && GameController.money - cost >= 0)
            {
                if (tile)
                {
                    gameObject.tag = "GunTower";
                    notBought = false;
                    GameController.money -= cost;
                    gameObject.transform.position = objectHit.transform.position;
                    Debug.Log("Placed!");
                    Debug.Log(objectHit.name);
                    objectHit.tag = "OccupiedTile";
                    objectHit.gameObject.layer = 6;
                }

            }
            //if right click, cancel
            if(Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }
        }
    }
    
}

    