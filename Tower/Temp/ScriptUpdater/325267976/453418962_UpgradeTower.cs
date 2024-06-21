using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject Gunner2;
    public GameObject Gunner3;
    public GameObject MiniGunner2;
    public GameObject MiniGunner3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {

        int type = GameController.FocusedTower.GetComponent<TowerShooting>().towerType;
        int tier = GameController.FocusedTower.GetComponent<TowerShooting>().tier;
        if (type == 0)
        {
            if (tier == 1)
            {
                GameObject TowerHighlight = Gunner2;
                TowerHighlight.GetComponent<TowerHighlight>().tilesParent = this.tilesParent;
                TowerHighlight.GetComponent<TowerHighlight>().camera = this.GetComponent<Camera>();
                Instantiate(Gunner2, GameController.FocusedTower.gameObject.transform.position, Quaternion.identity);
                
            }
            else if (tier == 2)
            {
                Instantiate(Gunner3, GameController.FocusedTower.gameObject.transform.position, Quaternion.identity);
                
            }
        }
        else if (type == 1)
        {
            if (tier == 1)
            {
                Instantiate(MiniGunner2, GameController.FocusedTower.gameObject.transform.position, Quaternion.identity);
                
            }
            else if (tier == 2)
            {
                Instantiate(MiniGunner3, GameController.FocusedTower.gameObject.transform.position, Quaternion.identity);
            }
        }
        Destroy(GameController.FocusedTower.gameObject);
        
    }
}
