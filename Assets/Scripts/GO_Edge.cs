using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO_Edge : MonoBehaviour
{
    public GameObject NodeFrom;
    public GameObject NodeTo;
    public Edge e;

    private void Awake()
    {
        e = new Edge(NodeFrom.GetComponent<GO_Node>().n, NodeTo.GetComponent<GO_Node>().n, GetDistance());
    }

    float GetDistance()
    {
        return Vector3.Distance(NodeFrom.transform.position, NodeTo.transform.position);
    }
}
