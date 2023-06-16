using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject enemy;
    public float speed;
    public int damage;
    private int enemyIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        if(TowerShooting.enemys.Count > 0)
        {
            for(int i = 0; i < TowerShooting.enemys.Count; i++)
            {
                if(Vector3.Distance(TowerShooting.enemys[i].transform.position, transform.position) < TowerShooting.range)
                {
                    enemy = TowerShooting.enemys[i];
                    enemyIndex = i;
                    i = 9999;
                        
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if(enemy != null)
        {
            Vector3 targetPostition = new Vector3(enemy.transform.position.x, this.transform.position.y, enemy.transform.position.z) ;
            this.transform.LookAt(targetPostition);
            transform.position += transform.forward * (speed * Time.deltaTime);
            if (Vector3.Distance(enemy.transform.position, transform.position) < .75f)
            {
                enemy.GetComponent<EnemyFollower>().health -= damage;
                
                Destroy(gameObject);
            }
        }
        else
        {
            if (enemyIndex < TowerShooting.enemys.Count - 1 && TowerShooting.enemys.Count > 1)
            {
                enemy = TowerShooting.enemys[enemyIndex+1];
            }
            else
            {
                Destroy(gameObject);
            }

        }
        
    }
    
}
