using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject Gunner2;
    public GameObject Gunner3;
    public GameObject DoubleGunner2;
    public GameObject DoubleGunner3;
    public Camera camera;
    public GameObject tilesParent;
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
                TowerHighlight.GetComponent<TowerHighlight>().camera = this.camera;
                Instantiate(TowerHighlight, GameController.FocusedTower.gameObject.transform.position, Quaternion.identity);
                
            }
            else if (tier == 2)
            {
                GameObject TowerHighlight = Gunner3;
                TowerHighlight.GetComponent<TowerHighlight>().tilesParent = this.tilesParent;
                TowerHighlight.GetComponent<TowerHighlight>().camera = this.camera;
                Instantiate(TowerHighlight, GameController.FocusedTower.gameObject.transform.position, Quaternion.identity);
                
            }
        }
        else if (type == 1)
        {
            if (tier == 1)
            {
                GameObject TowerHighlight = DoubleGunner2;
                TowerHighlight.GetComponent<TowerHighlight>().tilesParent = this.tilesParent;
                TowerHighlight.GetComponent<TowerHighlight>().camera = this.camera;
                Instantiate(TowerHighlight, GameController.FocusedTower.gameObject.transform.position, Quaternion.identity);
                
            }
            else if (tier == 2)
            {
                GameObject TowerHighlight = DoubleGunner3;
                TowerHighlight.GetComponent<TowerHighlight>().tilesParent = this.tilesParent;
                TowerHighlight.GetComponent<TowerHighlight>().camera = this.camera;
                Instantiate(TowerHighlight, GameController.FocusedTower.gameObject.transform.position, Quaternion.identity);
            }
        }
        Destroy(GameController.FocusedTower.gameObject);
        
    }
}
