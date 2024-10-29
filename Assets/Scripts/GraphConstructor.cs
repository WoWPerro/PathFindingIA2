using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GraphConstructor : MonoBehaviour
{
    // P List GameObject Nodes
    // P List GameObject Edges
    // Conectar Nodes con Edges 

    public List<GameObject> nodes;
    public List<GameObject> edges;
    Graph graph;


    // Start is called before the first frame update
    void Start()
    {
        Graph graph = new Graph();
        IterateNodes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IterateNodes()
    {
        foreach (GameObject node in nodes)
        {
            graph.Add(node.GetComponent<GO_Node>().n);
        }
    }
}
