using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface surface;

    public static bool build = true;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.start && build)
        {
            surface.BuildNavMesh();
            build = false;
        }
    }

    public static void BuildNav()
    {
        
    }
}
