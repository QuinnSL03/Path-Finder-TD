using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootAnimation : MonoBehaviour
{
    public float length;
    public float speed;
    private float time;
    public bool shoot;


    // Start is called before the first frame update
    void Start()
    {
        shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > Math.PI)
        {
            shoot = false;
            time = 0;
        }
        if (shoot)
        {
            time += Time.deltaTime;
            transform.position -= transform.forward * (float)(Math.Cos(time * speed) * length);
        }

       
    }
    
}
