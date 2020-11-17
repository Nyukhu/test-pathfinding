using System;
using System.Collections.Generic;

public class Node
{
    public string name;
    public float x, y, z;
    public int cost;

    public List<Node> neighbours = new List<Node>();

    public Node(string name, float x, float y, int cost, float z = 0)
    {
        this.name = name;
        this.x = x;
        this.y = y;
        this.z = z;
        this.cost = cost;
    }
    public override bool Equals(object obj)
    {
        if (obj is Node otherNode)
        {
            if(this.x == otherNode.x && this.y == otherNode.y && this.z == otherNode.z)
            {
                return true;
            }
            return false;
        }
        return false;
    }

    

}