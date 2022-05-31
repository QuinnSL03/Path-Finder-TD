using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    GameObject point;
    public float speed = .05f;
    float time;
    int length; 
    int pointIndex = 0;
    public static bool turnOn;
   
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.FindWithTag("PathPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turnOn)
        {
            length = point.transform.childCount;
        
            time += Time.deltaTime;
            transform.LookAt(point.transform.GetChild(pointIndex).position);
            transform.position += transform.forward * speed;
            if(Vector3.Distance(point.transform.GetChild(pointIndex).position, transform.position) < .2)
            {
                pointIndex++;
                Debug.Log(pointIndex);
                if(pointIndex == length)
                {
                    //reached end point, take life.
                    Destroy(gameObject);
                }   
            }
        }
        
    }
}
