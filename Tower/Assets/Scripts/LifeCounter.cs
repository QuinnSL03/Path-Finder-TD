using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCounter : MonoBehaviour
{
    private TMP_Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = GameController.health + "/25";
    }

    
}
