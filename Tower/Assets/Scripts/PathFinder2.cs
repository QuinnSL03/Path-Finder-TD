using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder2 : MonoBehaviour
{
    public Transform endPoint;
    public NavMeshAgent agent;
    Transform tileObject;
    Color color = new Color(0.2f, 1f, 0.2f, 1f);

    public static List<GameObject> pathTiles = new List<GameObject>();
    int index = 0;
    public static bool done = false;
    GameObject pointParent;

    public static bool updateNav = false;
    // Start is called before the first frame update
    void Start()
    {
        endPoint = GameController.endPoint.transform;
        pointParent = GameObject.FindWithTag("Point");
        for(int i = 0; i < pointParent.transform.childCount; i++)
        {
            if(pointParent.transform.GetChild(i).childCount == 1)
            {
                pointParent.transform.GetChild(i).transform.GetChild(0).tag = "Tile";
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.start)
        {
            RaycastHit hit;
            agent.SetDestination(endPoint.transform.position);
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                tileObject = hit.transform;
                if (tileObject.CompareTag("Tile"))
                {
                    tileObject.GetComponent<Renderer>().material.SetColor("_Color", color);
                    if (!pathTiles.Contains(tileObject.transform.gameObject))
                    {
                        pathTiles.Add(tileObject.transform.gameObject);
                        tileObject.tag = "PathTile";
                    }
                }

            }
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        // Done
                        done = true;
                        Destroy(gameObject);
                     
                    }
                }
            }
        }
    }

}

