using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public interface IPercourable
{
    List<Node> shortestPath(Node start,Node end);

}