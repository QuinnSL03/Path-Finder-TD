using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int money = 200;
    public GameObject Enemy;
    public static GameObject endPoint;
    public GameObject end;
    float time;
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
        count++;
        time += Time.deltaTime;
        if(createNewPath)
        {
            Instantiate(pathFinder, startPosition.transform.position, Quaternion.identity);
            createNewPath = false;
        }

        if(count % 100 == 0 && PathFinder2.done)
        {
            Instantiate(Enemy, startPosition.transform.position, Quaternion.identity);
        }


    }
    public static void setStart(bool s)
    {
        start = s;
        createNewPath = true;
    }
    

}
