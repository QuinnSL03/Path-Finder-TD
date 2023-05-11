using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject enemy;
    
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
            transform.position += transform.forward * .5f;

        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionStay(Collision other) {
        Debug.Log("Deleted!");
        Destroy(gameObject);
    }
}
