using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Grids : MonoBehaviour
{
    //these are the variables needed in this script 
    public int Diameter;
    public int Xlength;
    public int Ylength;
    public float Xscale, Yscale;
    public Node[,] Map;
    public LayerMask Walls;
    public Vector2 Edges;
    // used to reference over a path from the Astar script
    public List<Node> path;

    void Start()
    {
        // the following code executes the Initialise procedure
        Initialise();
        // the following code executes the MakeMap script
        MakeMap();
        print(Map[3, 3].Walkable);
        //NeighbourOfPoint(GetNodeFromWorld(temp.position));//so we can do here is literally call one function inside another
    }
    public void Initialise()// initialise at runtime
    {
        // creates diameter of value 1
        Diameter = 1;// this can be changed if you want larger cubes
        // the Xscale and Yscale, scale the x and z values for the grid
        Xscale = transform.localScale.x;
        Yscale = transform.localScale.z;
        // the Xlength and Ylength create the lengths for the grid
        Xlength = (int)(Xscale * 10);
        Ylength = (int)(Yscale * 10);
        // the following adds the nodes to the map
        Map = new Node[Xlength, Ylength];
        // the following code creates the edges for the map
        Edges = new Vector2(Xlength / 2, Ylength / 2);
    }
    // this is a list because it is returning a list type. It cannot return a list if the function can only return
    // single values. 
    public List<Node> NeighbourOfPoint(Node Point)
    {
        // the follwing code stores the nodes on a list data structure
        List<Node> neighbourofpoint = new List<Node>();
        // the following code gets the position of the nodes by adding or subtracting 1
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)// this should work
            {
                // checks whether the x and y values are equal to 0 or not
                if (x == 0 && y == 0)
                {
                    // skips 0 because this will return the original pos.
                    continue;
                }
                // finds the x value of the position of neighers
                int XNeighbour = Point.x + x;
                // finds the y value of the position of neighbours
                int YNeighbour = Point.y + y;
                // checks whether the neighbours arent out of range
                if (XNeighbour > 0 && XNeighbour < Xlength && YNeighbour > 0 && YNeighbour < Ylength)
                {
                    // if the neighbours are within range, it adds them to the map.
                    neighbourofpoint.Add(Map[XNeighbour, YNeighbour]);
                }
            }
        }
        // returns the neighbours of the points
        return neighbourofpoint;
    }

    // gets the position of the nodes
    public Node GetNodeFromWorld(Vector2 Position)
    {
        // sets the value of node to null
        Node node = null;

        for (int x = 0; x < Xlength; x++)
        {
            for (int y = 0; y < Ylength; y++)
            {
                // makes sure that its all positive
                int tempx = Mathf.Abs((int)Position.x - (int)Map[x, y].Position.x);
                int tempy = Mathf.Abs((int)Position.y - (int)Map[x, y].Position.y);
                if (tempx <= 0.5f && tempy <= 0.5f)
                {
                    // sets the value of node to the values of x and y within Map
                    node = Map[x, y];
                }
            }
        }
        // returns the nodes
        return node;
    }

    // the following procedure creates the map
    public void MakeMap()
    {
        // sets the value of the radius to half of diameter ( uses diameter so that if diameter is changed, 
        // the radius value is changed also automatically
        float radius = Diameter / 2;
        
        for (int x = 0; x < Xlength; x++)
        {
            for (int y = 0; y < Ylength; y++)
            {
                // calculates the posistion of each node (cross sections in grid)
                Vector2 CalculationofPosition = new Vector2((Edges.x - Diameter * x) - 0f, (Edges.y - Diameter * y) - 0f);
                // creates a boolean for whether the pathfinding can can walk through
                // so that the enemy doesnt walk through walls etc
                bool canwalk = !(Physics2D.OverlapCircle(CalculationofPosition, 0.5f, Walls));
                // adds the nodes to Map[x, y]
                Map[x, y] = new Node(CalculationofPosition, x, y, canwalk);
            }
        }
    }

    // draws the grid
    void OnDrawGizmos()
    {
        // sets the colour of the grid to red
        Gizmos.color = Color.red;
        for (int x = 0; x < Xlength; x++)
        {
            for (int y = 0; y < Ylength; y++)
            {
                // checks whether the pathfinding is appropiate at the points or not
                if (Map[x, y].Walkable)
                {
                    // if its appropiate, the following code draws a grid there
                    Gizmos.DrawWireCube(Map[x, y].Position, new Vector3(Diameter, Diameter, 0));
                }
            }
        }
// checks whether the path is not null (path to the player)
        if (path != null)
        {
            // sets the colour of the nodes to green
            Gizmos.color = Color.green;
            for (int i = 0; i < path.Count; i++)
            {
                // creates the path to the player
                Gizmos.DrawCube(path[i].Position, new Vector3(Diameter, Diameter, 0));
            }
        }
        // 
        Matrix4x4 rotation = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.matrix = rotation;
        Gizmos.DrawWireCube(transform.position, new Vector3(Xlength, 0, Ylength));
    }
}
