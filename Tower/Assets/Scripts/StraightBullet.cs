using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StraightBullet : MonoBehaviour
{
    GameObject enemy;
    public float speed;
    public int damage;
    private int enemyIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
        

        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyFollower>().health -= damage;
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
