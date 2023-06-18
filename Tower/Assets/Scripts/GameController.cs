using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static int money = 200;
    public GameObject Enemy;
    public GameObject StrongEnemy;
    public GameObject FastEnemy;
    public static GameObject endPoint;
    public GameObject end;
    private bool spawning = true;
    float time;
    private float spawnTimer1 = 0;
    private float spawnTimer2 = 0;
    private float spawnTimer3 = 0;
    private float spawnRate = 2;
    int count;
    public static bool start = false;
    public GameObject startPosition;
    public GameObject pathFinder;
    public static bool createNewPath = false;
    private Color white = new Color(254f, 254f, 254f);
    private int wave = 0;

    private bool temp = true;
    // Start is called before the first frame update
    void Start()
    {
        endPoint = end;
    }

    // Update is called once per frame
    void Update()
    {
        if (createNewPath)
        {
            
            if (TowerShooting.enemys.Count == 0 && start)
            {
                PathFinder2.pathTiles.Clear();
                Debug.Log("createnewpath");
                spawning = false;
                NavMeshBaker.build = true;
                Instantiate(pathFinder, startPosition.transform.position, Quaternion.identity);
                createNewPath = false;
            }
            
        }

        if (PathFinder2.done && start)
        {
            spawning = true;
            time += Time.deltaTime;
            if (wave < (int)(time * .05f) +1 && wave != 0)
            {
                createNewPath = true;
                foreach (GameObject tile in PathFinder2.pathTiles)
                {
                    tile.GetComponent<Renderer>().material.SetColor("_Color", white);
                    if (tile.CompareTag("PathTile"))
                    {
                        tile.tag = "Tile";
                    }
                    
                   
                }
                start = false;
                temp = true;
            }
            wave = (int)(time * .05f) + 1;
            
            
        }

        if (spawning)
        {
            switch (wave)
            {
                case 1:
                    Wave1();
                    break;
                case 2:
                    Wave2();
                    break;
                case 3:
                    Wave3();
                    break;
                case 4:
                    Wave4();
                    break;
                case 5:
                    Wave5();
                    break;
                case 6:
                    Wave6();
                    break;
                case 7:
                    Wave7();
                    break;
                case 8:
                    Wave8();
                    break;
                case 9:
                    Wave9();
                    break;
                case 10:
                    Wave10();
                    break;
                case 11:
                    Wave11();
                    break;
                case 12:
                    Wave12();
                    break;
                case 13:
                    Wave13();
                    break;
                case 14:
                    Wave14();
                    break;
                case 15:
                    Wave15();
                    break;
            
            }
        }

        else
        {
           Debug.Log("blocking spawning");
        }
        //This Wave System is VERY inefficient but IDC, i like the way it reads and that is all that matters! :).



    }

    private void Wave1()
    {
        if(time - spawnTimer1 >= 1f && PathFinder2.done)
        {
            Instantiate(Enemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer1 = time;
        }
        //Debug.Log("Wave 1");
    }
    private void Wave2()
    {
        if(time - spawnTimer1 >= 1f && PathFinder2.done)
        {
            Instantiate(Enemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer1 = time;
        }
        if(time - spawnTimer2 >= 5f && PathFinder2.done)
        {
            Instantiate(StrongEnemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer2 = time;
        }
        
        //Debug.Log("Wave 2");
    }
    private void Wave3()
    {
        if(time - spawnTimer1 >= .3f && PathFinder2.done)
        {
            Instantiate(Enemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer1 = time;
        }
        if(time - spawnTimer2 >= 10f && PathFinder2.done)
        {
            Instantiate(StrongEnemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer2 = time;
        }
        //Debug.Log("Wave 3");
    }
    private void Wave4()
    {
        if(time - spawnTimer1 >= .3f && PathFinder2.done)
        {
            Instantiate(Enemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer1 = time;
        }
        if(time - spawnTimer2 >= 5f && PathFinder2.done)
        {
            Instantiate(StrongEnemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer2 = time;
        }
    }
    private void Wave5()
    {
        if(time - spawnTimer1 >= 2f && PathFinder2.done)
        {
            Instantiate(Enemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer1 = time;
        }
        if(time - spawnTimer2 >= 1f && PathFinder2.done)
        {
            Instantiate(StrongEnemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer2 = time;
        }
    }
    private void Wave6()
    {
        if(time - spawnTimer1 >= 2f && PathFinder2.done)
        {
            Instantiate(Enemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer1 = time;
        }
        if(time - spawnTimer2 >= 1f && PathFinder2.done)
        {
            Instantiate(StrongEnemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer2 = time;
        }
        if(time - spawnTimer3 >= 1f && PathFinder2.done)
        {
            Instantiate(FastEnemy, startPosition.transform.position, Quaternion.identity);
            spawnTimer3 = time;
        }
    }
    private void Wave7()
    {
        
    }
    private void Wave8()
    {
        
    }
    private void Wave9()
    {
        
    }
    private void Wave10()
    {
        
    }
    private void Wave11()
    {
        
    }
    private void Wave12()
    {
        
    }
    private void Wave13()
    {
        
    }
    private void Wave14()
    {
        
    }
    private void Wave15()
    {
        
    }
    public static void setStart(bool s)
    {
        start = s;
        createNewPath = true;
    }
    

}
