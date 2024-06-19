using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerInfo : MonoBehaviour
{
    public TMP_Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setTowerType(string type)
    {
        myText.text = type;
    }
    
    public void setDmgDone(int dmg)
    {
        myText.text = "" + dmg;
    }
}
