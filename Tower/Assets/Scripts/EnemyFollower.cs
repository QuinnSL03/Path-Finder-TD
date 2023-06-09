using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    public float distanceTraveled;
    public float speed = .02f;
    float time;
    int length; 
    int pointIndex = 0;
    public GameObject particle;
    public int health = 25;
   
    // Start is called before the first frame update
    void Start()
    {
        TowerShooting.enemys.Add(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PathFinder2.done)
        {
            length = PathFinder2.pathTiles.Count;
        
            time += Time.deltaTime;
            distanceTraveled += speed;
            transform.LookAt(PathFinder2.pathTiles[pointIndex].transform.position);
            transform.position += transform.forward * speed;
            if(Vector3.Distance(PathFinder2.pathTiles[pointIndex].transform.position, transform.position) < .1)
            {
                gameObject.transform.position = PathFinder2.pathTiles[pointIndex].transform.position;
                pointIndex++;
                //Debug.Log(pointIndex);
                if(pointIndex == length)
                {
                    //reached end point, take life.
                    TowerShooting.enemys.Remove(gameObject);
                    Destroy(gameObject);
                    //use different particle
                    //Instantiate(particle, transform.position, transform.rotation * Quaternion.Euler (-90f, 0f, 0f));
                }   
            }
        }
        //gunned down
        if(health <= 0)
        {
            TowerShooting.enemys.Remove(gameObject);
            Destroy(gameObject);
            Instantiate(particle, transform.position, transform.rotation * Quaternion.Euler (-90f, 0f, 0f));
            GameController.money += 10;
        }
        
        
    }
}
