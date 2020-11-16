using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGraph : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Node nodeA1 = new Node("a1", 0, 0, 1);
        Node nodeA2 = new Node("a2", 0, 1, 1);
        Node nodeA3 = new Node("a3", 0, 2, 1);
       
        Node nodeB1 = new Node("b1", 1, 0, 1);
        Node nodeB2 = new Node("b2", 1, 1, 999);
        Node nodeB3 = new Node("b3", 1, 2, 1);
       
        Node nodeC1 = new Node("c1", 2, 0, 1);
        Node nodeC2 = new Node("c2", 2, 1, 1);
        Node nodeC3 = new Node("c3", 2, 2, 1);
        
        Node nodeD1 = new Node("d1", 3, 0, 1);
        Node nodeD2 = new Node("d2", 3, 1, 1);
        Node nodeD3 = new Node("d3", 3, 2, 1);
       
        Node nodeE1 = new Node("e1", 4, 0, 1);
        Node nodeE2 = new Node("e2", 4, 1, 1);
        Node nodeE3 = new Node("e3", 4, 2, 1);
        

        nodeA1.neighbours.Add(nodeA2);
        nodeA1.neighbours.Add(nodeB1);

        nodeA2.neighbours.Add(nodeA1);
        nodeA2.neighbours.Add(nodeA3);
        nodeA2.neighbours.Add(nodeB2);

        nodeA3.neighbours.Add(nodeA2);
        nodeA3.neighbours.Add(nodeB3);

        nodeB1.neighbours.Add(nodeA1);
        nodeB1.neighbours.Add(nodeB2);
        nodeB1.neighbours.Add(nodeC1);

        nodeB2.neighbours.Add(nodeA2);
        nodeB2.neighbours.Add(nodeB1);
        nodeB2.neighbours.Add(nodeB3);
        nodeB2.neighbours.Add(nodeC2);

        nodeB3.neighbours.Add(nodeA3);
        nodeB3.neighbours.Add(nodeB2);
        nodeB3.neighbours.Add(nodeC3);

        nodeC1.neighbours.Add(nodeC2);
        nodeC1.neighbours.Add(nodeB1);

        nodeC2.neighbours.Add(nodeC1);
        nodeC2.neighbours.Add(nodeC3);
        nodeC2.neighbours.Add(nodeB2);

        nodeC3.neighbours.Add(nodeC2);
        nodeC3.neighbours.Add(nodeB3);

        MapGraph graph = new MapGraph();
        graph.graph.Add(nodeA1);
        graph.graph.Add(nodeA2);
        graph.graph.Add(nodeA3);
        graph.graph.Add(nodeB1);
        graph.graph.Add(nodeB2);
        graph.graph.Add(nodeB3);
        graph.graph.Add(nodeC1);
        graph.graph.Add(nodeC2);
        graph.graph.Add(nodeC3);

        List<Node> path = graph.shortestPath(nodeA2, nodeC3);
        path.ForEach(node =>
        {
            Debug.Log("tile " + node.name );

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
