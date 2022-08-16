using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShooterTower : MonoBehaviour
{
    public float damage;
    public static float range = 6;
    GameObject enemy = null;
    public static List<GameObject> enemys = new List<GameObject>();
    public GameObject bullet;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(!gameObject.GetComponent<TowerHighlight>().notBought)
        {
            //Debug.Log(enemys.Count);
            //finds the closest and farthest down the path enemy
            if(enemys.Count > 0)
            {
                for(int i = 0; i < enemys.Count; i++)
                {
                    if(Vector3.Distance(enemys[i].transform.position, transform.position) < range)
                    {
                        enemy = enemys[i];
                        i = 9999;
                        
                    }
                }
            }

            if(enemy != null)
            {
                Vector3 targetPostition = new Vector3(enemy.transform.position.x, this.transform.position.y, enemy.transform.position.z) ;
                this.transform.LookAt(targetPostition);
                if(count > 50)
                {
                    Shoot();
                    count = 0;
                    enemy.GetComponent<EnemyFollower>().health -= 25;
                }

            }
        }

        
    }

    void Shoot()
    {
        Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + .5f, gameObject.transform.position.z), transform.rotation * Quaternion.Euler (90f, 0f, 0f));
        
    }
}
