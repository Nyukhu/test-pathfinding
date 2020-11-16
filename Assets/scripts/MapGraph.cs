using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class MapGraph :IPercourable
{
    public List<Node> graph = new List<Node>();
    private List<Node> openList = new List<Node>();
    private List<Node> closedList = new List<Node>();

    public List<Node> shortestPath(Node start, Node end)
    {
        List<Node> path = new List<Node>();
        this.openList.Add(start);

        
        float gScore = 0;
        Dictionary < Node,float> hScores = new Dictionary<Node, float>();
        Dictionary < Node,float> gScores = new Dictionary<Node, float>();
        Dictionary < Node,float> fScores = new Dictionary<Node, float>();
        Dictionary < Node, Node> cameFrom = new Dictionary<Node, Node>();

        gScores.Add(start, 0);
        hScores.Add(
            start, 
            heuristic( 
                Mathf.Abs(start.x - end.x), 
                Mathf.Abs(start.y - end.y)
            )
        );
        fScores.Add(start, gScores[start] + hScores[start]);

        int i;
        int j;

        Node current = getGraphNode(openList[0]);
       

        while (openList.Count > 0)
        {
            Debug.Log("looped");

            

            //recherche du node avec le plus petit Fscore s'il y a plus d'un element dans le tableau
            if (openList.Count > 1)
            {
                float fScore = float.MaxValue;
                int min = 0;
                for(i = 0; i < openList.Count; i++)
                {
                    current = getGraphNode(openList[i]);
                    if (fScores.ContainsKey(current))
                    {
                        fScore = Mathf.Min(fScores[current], fScore);
                        if(fScore == fScores[current])
                        {
                            min = i;
                        }
                    }
                    else
                    {
                        if (!hScores.ContainsKey(current))
                        {
                            hScores.Add(
                               current,
                               heuristic(
                                   Mathf.Abs(current.x - end.x),
                                   Mathf.Abs(current.y - end.y)
                               )
                           );
                        }

                        fScores.Add(current, gScores[current] + hScores[current]);

                        fScore = Mathf.Min(fScores[current], fScore);
                        if (fScore == fScores[current])
                        {
                            min = i;
                        }
                    }

                }

                current = getGraphNode(openList[min]);
                Debug.Log("min :" + current.name);
                openList.RemoveAt(min);
            }

            closedList.Add(current);
            openList.Remove(current);

            if (current == end)
            {
                return reconstructPath(cameFrom, current);
            }

            Debug.Log("the current node is " + current.name);
            int numberOfNeighbours = current.neighbours.Count;
            for (j = 0; j < numberOfNeighbours; j++)
            {
                Node neighbour = getGraphNode(current.neighbours[j]);
                if (closedList.Contains(neighbour))
                {
                    continue;
                }


                float testGScore = gScores[current] + (neighbour.cost - current.cost);

                if(!openList.Contains(neighbour) || testGScore < gScores[neighbour])
                {
                    Debug.Log("test " + neighbour.name);
                    
                    cameFrom.Add(neighbour, current);
                    
                    
                    //gScores.Add(neighbour, gScore);
                    gScores[neighbour] = testGScore;
                    //fScores.Add(neighbour,gScores[neighbour] + heuristic(Mathf.Abs(neighbour.x - end.x),Mathf.Abs(neighbour.y - end.y)))
                    fScores[neighbour] = gScores[neighbour] + heuristic(Mathf.Abs(neighbour.x - end.x), Mathf.Abs(neighbour.y - end.y));

                    if (!openList.Contains(neighbour))
                        openList.Add(neighbour);
                }
            }

        }
        return path;
    }

    private float heuristic(float dx, float dy)
    {
       return Mathf.Sqrt(dx * dx + dy * dy);
    }
    public Node getGraphNode(Node node)
    {
        return this.graph.Find(graphNode => graphNode == node);
    }

    private List<Node> reconstructPath(Dictionary<Node, Node> cameFrom,Node current)
    {
        List<Node> path = new List<Node>();
        path.Add(current);
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            path.Add(current);
            
        }
        path.Reverse();
        return path;
    }
}