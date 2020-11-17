using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GraphBuilder
{

    //public GameObject map;
    //float nodeSpacing = 1f;
   
    public List<Node> createGraphFrom2DSquareMap(GameObject map)
    {
        List<Node> generatedGraph = new List<Node>();

        float mapX = map.transform.position.x;
        float mapZ = map.transform.position.z;

        float mapsizeX = map.GetComponent<Renderer>().bounds.size.x;
        float mapsizeZ = map.GetComponent<Renderer>().bounds.size.z;
        //Debug.Log(testmapsizeX + " | " + testmapsizeZ);
        //float mapsizeX = map.transform.localScale.x;
        //float mapsizeZ = map.transform.localScale.z;

        float nodeSpacing = 1f;

        Debug.Log(mapX + " | " + mapZ + " | " + mapsizeX + " | " + mapsizeZ);

        float minX = mapX - (mapsizeX / 2);
        float maxX = mapX + (mapsizeX / 2);
        float minZ = mapZ - (mapsizeZ / 2);
        float maxZ = mapZ + (mapsizeZ / 2);

        Debug.Log(minX + " | " + maxX + " | " + minZ + " | " + maxZ);


        for (float i = minX; i < maxX; i += nodeSpacing)
        {
            for (float j = minZ; j < maxZ; j += nodeSpacing)
            {
                Node newNode =new Node("node(" + i + "|" + j + ")",i,j, 1) ;
                Debug.Log("node created :" + newNode.name);

                generatedGraph.Add(newNode);
            }
        }

        List<Node> linkedGraph = this.linkNeighbours(generatedGraph, nodeSpacing);

        return linkedGraph;
    }

    private List<Node> linkNeighbours(List<Node> generatedGraph, float nodeSpacing)
    {
        generatedGraph.ForEach(node =>
       {
           for (float i = -nodeSpacing; i <= nodeSpacing; i += nodeSpacing)
           {
               for (float j = -nodeSpacing; j <= nodeSpacing; j += nodeSpacing)
               {
                   
                       Node neighbourNode = generatedGraph.Find(nodeToFind => {
                           
                           if (nodeToFind.x == node.x + i && nodeToFind.y == node.y + j)
                           {
                               return true;

                           }
                           return false;
                       });
                       
                       if (neighbourNode != null)
                       {
                           node.neighbours.Add(neighbourNode);
                           Debug.Log("neighbourNode found :" + neighbourNode.name);
                       }


               }
           }
       });
        return generatedGraph;
    }
    private Node checkForNeighbours()
    {
        throw new NotImplementedException();
    }
}
