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
    private int tempHealth;
    public GameObject particle;
    public int health = 1000;
    Color damageIndicator = new Color(0.8868628f, 0.4f, 0.4196078f, .75f);
    public Color normalColor = new Color();
    private Renderer renderer;
    private float flashTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        TowerShooting.enemys.Add(gameObject);
        tempHealth = health;


    }

    // Update is called once per frame
    void Update()
    {
        if(PathFinder2.done)
        {
            if (health != tempHealth)
            {
                if (flashTime == 0)
                {
                    renderer.material.SetColor("_Color", damageIndicator);
                    flashTime = time;
                }

                if (time - flashTime >= .2)
                {
                    renderer.material.SetColor("_Color", normalColor);
                    tempHealth = health;
                    flashTime = 0;
                }    
                
            }
            
            length = PathFinder2.pathTiles.Count;
        
            time += Time.deltaTime;
            distanceTraveled += speed * Time.deltaTime;
            transform.LookAt(PathFinder2.pathTiles[pointIndex].transform.position);
            transform.position += transform.forward * (speed * Time.deltaTime);
            if(Vector3.Distance(PathFinder2.pathTiles[pointIndex].transform.position, transform.position) < .1)
            {
                gameObject.transform.position = PathFinder2.pathTiles[pointIndex].transform.position;
                pointIndex++;
                //Debug.Log(pointIndex);
                if(pointIndex == length)
                {
                    //reached end point, take life.
                    GameController.health -= 1;
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
