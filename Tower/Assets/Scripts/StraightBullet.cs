using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class StraightBullet : MonoBehaviour
{
    GameObject enemy;
    public float speed;
    public int damage;
    private int enemyIndex;
    private float count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 2.5f)
        {
            Destroy(gameObject);
        }
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
