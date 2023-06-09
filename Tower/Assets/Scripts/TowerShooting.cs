using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public int damage = 25;
    public static float range = 6;
    GameObject enemy = null;
    public static List<GameObject> enemys = new List<GameObject>();
    public GameObject bullet;
    public int shootingFrequency;
    public int towerType;
    int count;
    bool secondShot = false;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
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
                //Gunner
                if (towerType == 0)
                {
                    Vector3 targetPostition = new Vector3(enemy.transform.position.x, this.transform.position.y,
                        enemy.transform.position.z);
                    this.transform.LookAt(targetPostition);
                    if (time > .6f)
                    {
                        Shoot();
                        time = 0;
                        enemy.GetComponent<EnemyFollower>().health -= damage;
                    }
                }
                //Double Gunner
                if (towerType == 1)
                {
                    Vector3 targetPostition = new Vector3(enemy.transform.position.x, this.transform.position.y,
                        enemy.transform.position.z);
                    this.transform.LookAt(targetPostition);
                    if (time > 1.2f && secondShot)
                    {
                        secondShot = false;
                        DualShoot(0.2f);
                        Debug.Log("1");
                    }
                    if (time > 1.5f)
                    {
                        secondShot = true;
                        DualShoot(-0.2f);
                        time = 0;
                        Debug.Log("2");
                    }
                    
                }

            }
        }

        
    }

    void Shoot()
    {
        Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + .5f, gameObject.transform.position.z), transform.rotation * Quaternion.Euler (90f, 0f, 0f));
        GetComponentInChildren<ShootAnimation>().shoot = true;
    }

    void DualShoot(float offset)
    {
        Instantiate(bullet, new Vector3(gameObject.transform.position.x + offset, gameObject.transform.position.y + .5f, gameObject.transform.position.z), transform.rotation * Quaternion.Euler (90f, 0f, 0f));
        foreach (ShootAnimation gun in GetComponentsInChildren<ShootAnimation>())
        {
            gun.shoot = true;
        }
        
    }
}
