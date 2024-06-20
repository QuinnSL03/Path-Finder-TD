using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerTier : MonoBehaviour
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
        myText.text = "Tier = " + GameController.FocusedTower.GetComponent<TowerShooting>().tier;
    }
    
}
