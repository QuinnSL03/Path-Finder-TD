using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder2 : MonoBehaviour
{
    public int width;
    public int height;
    // Start is called before the first frame update
    void Start()
    {
        float[,] tilesmap = new float[width, height];
        PathFind.Grid grid = new PathFind.Grid(width, height, tilesmap);
        PathFind.Point _from = new PathFind.Point(1, 1);
        PathFind.Point _to = new PathFind.Point(10, 10);
        List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, _from, _to);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
