using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class WindMill : MonoBehaviour
{
    public int moneyAmount;
    public float moneyRate; 
    private float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,3,0);
        time += Time.deltaTime;
        if (!gameObject.GetComponent<TowerHighlight>().notBought && GameController.start)
        {
            if (time > moneyRate){
                GenerateMoney();
                time = 0;
            }
        }
    }
    void GenerateMoney(){
        GameController.money += moneyAmount;
    }
    void OnMouseDown()
    {
        GameController.FocusedTower = gameObject;
    }
}
