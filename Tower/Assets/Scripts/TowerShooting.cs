using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    bool secondShot = true;
    float secondShotTime = 0;

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
                Vector3 targetPostition = new Vector3(enemy.transform.position.x, this.transform.position.y, enemy.transform.position.z);
                //Gunner
                if (towerType == 0)
                {
                    
                    
                    if (time > 1f)
                    {
                        Shoot();
                        this.transform.LookAt(targetPostition);
                        time = 0;
                        
                    }
                }
                //Double Gunner
                if (towerType == 1)
                {
                    if (time > .5f && secondShot)
                    {
                        secondShot = false;
                        secondShotTime = time;
                        DualShoot(1);
                        this.transform.LookAt(targetPostition);
                        Debug.Log("1");
                    }
                    if (.5f < time - secondShotTime && !secondShot)
                    {
                        secondShot = true;
                        DualShoot(2);
                        this.transform.LookAt(targetPostition);
                        time = 0;
                        Debug.Log("2");
                    }
                    
                }

                if (towerType == 2)
                {
                    transform.GetChild(0).Rotate(0f, 0f, Time.deltaTime * 400);

                    if (time > .1f)
                    {
                        Shoot();
                        this.transform.LookAt(targetPostition);
                        time = 0;
                     
                    }
                }

            }
        }

        
    }

    void Shoot()
    {
        Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + .5f, gameObject.transform.position.z), transform.rotation * Quaternion.Euler (90f, 0f, 0f));
        foreach (ShootAnimation gun in GetComponentsInChildren<ShootAnimation>())
        {
            gun.shoot = true;
        }
        
    }

    void DualShoot(int i)
    {
        Instantiate(bullet, new Vector3(gameObject.transform.GetChild(i-1).transform.position.x, gameObject.transform.position.y + .5f, gameObject.transform.position.z), transform.rotation * Quaternion.Euler (90f, 0f, 0f));
        foreach (ShootAnimation gun in GetComponentsInChildren<ShootAnimation>())
        {
            if (i == 1)
            {
                gun.shoot = true;
            }

            i--;
 
        }
        
    }
}
