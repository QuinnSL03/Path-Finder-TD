using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour
{
    public GameObject tilesParent;
    GameObject TowerObj;
    float minDistanceMouse = 1.9f;
    Transform objectHit;
    public bool notBought = true;
    bool tile = false;
    Color selectedTile = new Color(0.7568628f, 0.4f, 0.4196078f, .75f);
    Color unselectedTile = new Color(1f, 1f, 1f, 1f);
    bool isSelected = false;

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
            
            if(Physics.Raycast(ray, out hit)) 
            {
                tile = true;
                isSelected = objectHit != hit.transform;
                if(objectHit != hit.transform && objectHit != null)
                {
                    objectHit.GetComponent<Renderer>().material.SetColor("_Color", unselectedTile);
                }
                objectHit = hit.transform;
                gameObject.transform.position = objectHit.transform.position;
                //objectHit.GetComponent<Renderer>().material.SetColor("_Color", selectedTile);

            }
            else if(objectHit != null && objectHit.CompareTag("Tile"))
            {
                objectHit.GetComponent<Renderer>().material.SetColor("_Color", unselectedTile);
                objectHit = null;
            }
            else
            {
                tile = false; 
            }
            if(isSelected & objectHit != null)
            {
                objectHit.GetComponent<Renderer>().material.SetColor("_Color", selectedTile);
            }

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // if left click, buy and place
            if(Input.GetMouseButtonDown(0) && tile && GameController.money - 25 >= 0)
            { 
                //if(objectHit.CompareTag("st"))
                {
                    //Destroys point and tile;
                    Destroy(objectHit.transform.gameObject);
                    notBought = false;
                    GameController.money -= 25;
                    Destroy(gameObject);
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

    