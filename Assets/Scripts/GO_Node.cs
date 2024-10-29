using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO_Node : MonoBehaviour
{
    public List<GameObject> GO_Edges;
    public Node n;

    private void Awake()
    {
        List<Edge> edges = new List<Edge>();
        
        foreach (GameObject e in GO_Edges)
        {
            edges.Add(e.GetComponent<GO_Edge>().e);
        }
        n = new Node(-1, 0, edges);
    }
}
