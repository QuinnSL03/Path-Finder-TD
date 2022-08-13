using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setStart()
    {
        GameController.setStart(true);
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Temp");   
        foreach (GameObject obj in taggedObjects) 
        {
            Debug.Log("Destroyed Temps" + taggedObjects.Length);
	        Destroy(obj);
        }
        gameObject.tag = "Temp";
    }
    
}
