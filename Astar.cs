﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Astar : MonoBehaviour
{
    // this class has been instantiated
    // the following are the variables used in this script
    Grids World;
    public Transform Player;
    public Transform AI;
    List<Node> Paths;
    public int UnitIndex;
    [SerializeField]
    public float AImovespeed;
    // this keeps a track of the units which are in the path list.
    public bool onUnit;

	void Start ()
    {
        // the following code gets the grid script
        World = GetComponent<Grids>();
	}

    void Moving()
    {
        // the following code calculates the distance from player 
        float distance = Vector2.Distance(AI.position, Paths[UnitIndex].Position);
        // the if statement checks how far the AI is from the player
        if (Paths.Count > 0)
        {
            // the following code sets a range to how far the AI could be before it stops
            if (distance <= 0.25f) 
            {
                // increments the UnitIndex
                UnitIndex++;
                // to say the ai is on the unit
                onUnit = true; 
            }
            else
            {
                // if the player is not within the range then it keeps moving in the direction of the player
                AI.position = Vector2.MoveTowards(AI.position, Paths[UnitIndex].Position, AImovespeed * Time.deltaTime);
            }
        }
        else
        {
            // this makes the AI move again
            onUnit = false;
        }
    }
    // this is a Coroutine what it does is , it acts like any other function
    // except it can be paused at certain steps, normally this cant be done with function 
    // because they get executed immediately
    IEnumerator Walking2()
    {
        // the following code sets the value of ObtainPathbyVector to the AI and player position
        ObtainPathbyVector(AI.position, Player.position);
        // the if statement checks whether the path count is not equal to 0
        if (Paths.Count != 0)
        {
            // this calls the Moving procedure
            Moving();
        }
        //notation for checking if something is true
        yield return new WaitUntil(()=> onUnit == true);
        // to make the AI move again
        onUnit = false; 
    }

    // the following procedure takes in two parameters, the star node and end node
    void PathGeneration(Node start, Node end)
    {
        // creates a new list of node
        Paths = new List<Node>();
        // this is where we retrace our path, so the positions required are reversed
        Node CurrentNode = end;
        while (CurrentNode != start)
        {
            Paths.Add(CurrentNode);
            // the following line of code changes the current node to the parent node (reversing)
            CurrentNode = CurrentNode.Parent;
        }
        // the following reverses the path
        Paths.Reverse();
        World.path = Paths;
    }
    // the following is for the main body of the A* algorithm
    void ObtainPathbyVector(Vector2 Start, Vector2 End)
    {
        // the following line of code assigns the starting node from the grid to the nodes script
        Node start = World.GetNodeFromWorld(Start);
        // the code underneath assigns the end node from the grid to the nodes script 
        Node end = World.GetNodeFromWorld(End);
        // this is to store all available points 
        List<Node> OpenPoints = new List<Node>();
        HashSet<Node> ClosePoints = new HashSet<Node>();
        // the following code adds the start point to the openlist
        OpenPoints.Add(start);
        // the loop below is executed until there are no open points left
        while (OpenPoints.Count > 0)
        {
            // the following line of code is used to initialise a current position
            Node CurrentPosition = OpenPoints[0];
            // for loop to run through f.cost is compared to openpoints
            for (int i = 0; i < OpenPoints.Count; i++)
            {
                // the following if statement checks whether the openpoints Fcos is smaller than the Fcos of the current position,
                // or the openpoints Fcos is equal to the Fcos of the current position
                if (OpenPoints[i].GetFcos < CurrentPosition.GetFcos || OpenPoints[i].GetFcos == CurrentPosition.GetFcos)
                {
                    // the following if statement checks whether the Hcos of the openpoints is smaller than
                    // the Hcos of the current position
                    if (OpenPoints[i].Hcos < CurrentPosition.Hcos)
                    {
                        //so now the current position will equal to whatever the most efficient path is
                        CurrentPosition = OpenPoints[i];
                    }
                }
            }
            // will store the most efficient path
            ClosePoints.Add(CurrentPosition);
            // removes the currentposition and moves on
            OpenPoints.Remove(CurrentPosition);
            // checks whether the current position is equal to the destination node
            if (CurrentPosition == end)
            {
                PathGeneration(start, end);
                //exits the loop
                return;
            }
            foreach (Node sidenode in World.NeighbourOfPoint(CurrentPosition))
            {
                // the following code gets access to unwalkable areas
                if (!sidenode.Walkable || ClosePoints.Contains(sidenode))// we say this because firstly we dont need to have access to unwalkable areas
                    //secondly there may be times where one of our side nodes has already been added to our closed list so we want to ignore those sidenodes
                {
                    // the continues ignores nodes that have already been added to the closed list and moves on
                    continue;
                }
                // will calculate any distances
                int MovementCost = CurrentPosition.Gcos + GetMoveCost(CurrentPosition, sidenode);
                // checks if this sidenode is good or not
                if (MovementCost < sidenode.Gcos || !OpenPoints.Contains(sidenode))
                {
                    // makes the Gcos value of the side node equal to movementcost
                    sidenode.Gcos = MovementCost;
                    // is where the value of Hcos is calculated
                    sidenode.Hcos = GetMoveCost(sidenode, end);
                    // need this parent to back track our path
                    sidenode.Parent = CurrentPosition;

                    // checks whether the open points dont contain sidenode
                    if (!OpenPoints.Contains(sidenode))
                    {
                        // adds new points to the list
                        OpenPoints.Add(sidenode);
                    }
                }
            }
        }
    }
    // checks how far the AI needs to travel from one single point to the other
    int GetMoveCost(Node A, Node B)
    {
        // calculates the distance by calculating the difference in the X and Y axis
        int Xdifference = Mathf.Abs(A.x - B.x);
        int Ydifference = Mathf.Abs(A.y - B.y);
        // variable name for the manhattan equation
        int ManhattanEquation;
        // the if statement checks whether the difference in X is greater than the difference in Y
        if (Xdifference > Ydifference)
        {
            // this equation depends on which value of x and y are larger. 
            // the following line performs the manhattan equation
            ManhattanEquation = 14 * Ydifference + 10 * (Xdifference - Ydifference);
            // returns the value obtained
            return ManhattanEquation;
        }
        ManhattanEquation = 14 * Ydifference + 10 * (Ydifference - Xdifference);
        return ManhattanEquation;
    }
    void Update()
    {
        // the follwing line of code starts the coroutine and makes the AI walk
        StartCoroutine(Walking2());
    }
}
