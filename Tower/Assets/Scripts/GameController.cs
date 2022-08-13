using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int money = 200;
    public GameObject Enemy;
    float time;
    int count;
    public static bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        time += Time.deltaTime; //hi
        if(count % 100 == 0 && PathFinder2.done)
        {
            Instantiate(Enemy, new Vector3(8.27f, .401f, -10.6f), Quaternion.identity);
            
            
        }
    }
    public static void setStart(bool s)
    {
        start = s;
    }
    

}
