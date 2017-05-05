using UnityEngine;
using System.Collections;
[System.Serializable]// this will help with debugging
public class Node
{
    // below are all the variables being used in thsi script and the Astar script
    public Vector2 Position;
    public int x;
    public int y;
    public bool Walkable;
    public int Hcos;
    public int Gcos;
    public Node Parent;

    public int GetFcos
    {
        // the code below gets the h and G value for the A* algorithm
        get
        {
            return Hcos + Gcos;
        }
    }

    // the follow precedure created the nodes for the grid and pathfinding
    // it also takes in three of the variables listed above
    public Node(Vector2 position, int X, int Y, bool walkable)
        {
        // the follwing code sets the value of x to X
        x = X;
        // the following code sets the value of y to Y
        y = Y;
        // the following code sets Walkable to walkable
        Walkable = walkable;
        // the following code sets Posistion to position
        Position = position;
        }
}
