using System;
using System.Collections.Generic;

public class Node
{
    public string name;
    public int x,y,cost;

    public List<Node> neighbours = new List<Node>();

    public Node(string name, int x, int y, int cost)
    {
        this.name = name;
        this.x = x;
        this.y = y;
        this.cost = cost;
    }

}