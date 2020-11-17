using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGraph : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject map;
    void Start()
    {
        List<GameObject> spawnedItems = new List<GameObject>();
        GraphBuilder graphBuilder = new GraphBuilder();


        List<Node> graph2D = graphBuilder.createGraphFrom2DSquareMap(map);

        MapGraph newMapGraph = new MapGraph();

        newMapGraph.graph = graph2D;

        graph2D.ForEach(node =>
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(node.x, node.z, node.y);
            if (node.cost > 900)
            {
                cube.GetComponent<MeshRenderer>().material.color = Color.black;
            }
            var cubeSize = transform.localScale;
            cubeSize.x = 0.8f;
            cubeSize.y = 0.1f;
            cubeSize.z = 0.8f;
            cube.transform.localScale = cubeSize;
            spawnedItems.Add(cube);

        });
        Node start = newMapGraph.graph[0];
        Node end = newMapGraph.graph[53];
        List<Node> path = newMapGraph.shortestPath(start, end);
        Debug.Log("neighbour : " + newMapGraph.graph[0].neighbours[0].name);
        Debug.Log(newMapGraph.graph[10].name);
        path.ForEach(node =>
        {
            Debug.Log("tile " + node.name );
            GameObject correspondingCube = spawnedItems.Find(cube =>
            {
                Debug.Log("compare : " + Mathf.Round(cube.transform.position.x * 100f));
                Debug.Log("compare to : " + Mathf.Round(node.x * 100f));
                if (Mathf.Round(cube.transform.position.x * 100f) == Mathf.Round(node.x * 100f) && Mathf.Round(cube.transform.position.z * 100f) == Mathf.Round(node.y * 100f))
                {
                    return true;
                }
                return false;
            });
            if(correspondingCube != null)
            {
                if(node == start || node == end)
                {
                    correspondingCube.GetComponent<MeshRenderer>().material.color = Color.green;

                }
                else
                {
                    correspondingCube.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        });

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
