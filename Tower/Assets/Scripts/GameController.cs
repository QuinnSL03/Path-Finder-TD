using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int money = 200;
    public GameObject Enemy;
    public GameObject StrongEnemy;
    public static GameObject endPoint;
    public GameObject end;
    float time;
    private float spawnTimer1;
    private float spawnTimer2;
    private float spawnTimer3;
    private float spawnRate = 2;
    int count;
    public static bool start = false;
    public GameObject startPosition;
    public GameObject pathFinder;
    public static bool createNewPath = false;
    // Start is called before the first frame update
    void Start()
    {
        endPoint = end;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer1 += Time.deltaTime;
        spawnTimer2 += Time.deltaTime;
        time += Time.deltaTime;
        if(createNewPath)
        {
            Instantiate(pathFinder, startPosition.transform.position, Quaternion.identity);
            createNewPath = false;
        }

        if(spawnTimer1 >= .5f && PathFinder2.done)
        {
            Instantiate(Enemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer1 = 0;
        }
        if(spawnTimer2 >= 3f && PathFinder2.done)
        {
            Instantiate(StrongEnemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer2 = 0;
        }

    }
    public static void setStart(bool s)
    {
        start = s;
        createNewPath = true;
    }
    

}
