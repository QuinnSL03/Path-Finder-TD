using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerHighlight : MonoBehaviour
{
    public GameObject tilesParent;
    public int cost;
    GameObject TowerObj;
    float minDistanceMouse = 1.9f;
    Transform objectHit;
    public bool notBought = true;
    bool tile;
    Collider TowerCollider;
    private int count = 1;
    public Camera camera;
    public bool upgradeTower;
    // Start is called before the first frame update
    void Start()
    {
        TowerCollider = GetComponent<Collider>();
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Temp");   
        foreach (GameObject obj in taggedObjects) 
        {
            Debug.Log("Destroyed Temps" + taggedObjects.Length);
	        Destroy(obj);
        }
        gameObject.tag = "Temp";
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeTower)
        {
            gameObject.tag = "GunTower";
            notBought = false;
            GameController.money -= cost;
            Debug.Log("Placed!");
            TowerCollider.enabled = !TowerCollider.enabled;
            upgradeTower = false;
        }
        //all this code only runs before you buy the tower
        if (notBought)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                objectHit = hit.transform;
                //Debug.Log("Hit Tile");
                if (hit.transform.gameObject.CompareTag("Tile"))
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
            if (Input.GetMouseButtonDown(0) && GameController.money - cost >= 0)
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
                    TowerCollider.enabled = !TowerCollider.enabled;
                }

            }

            //if right click, cancel
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }

            if (Input.GetKeyUp("r"))
            {
                transform.rotation = Quaternion.Euler(0f, 45f * count, 0f);
                count++;
            }
        }

    }
}

    