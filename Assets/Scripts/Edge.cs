using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    private Node nodeFrom;
    private Node nodeTo;
    private bool isVisited;
    private float peso;

    public Edge(Node _nodeFrom, Node _nodeTo, float _peso){
        this.nodeFrom = _nodeFrom;
        this.nodeTo = _nodeTo;
        this.isVisited = false;
        this.peso = _peso;
    }

    public void SetNodeFrom(Node _nodeFrom)
    {
        nodeFrom = _nodeFrom;
    }

    public Node GetNodeFrom() { 
        return nodeFrom; 
    }

    public void SetNodeTo(Node _nodeTo)
    {
        nodeTo = _nodeTo;
    }

    public Node GetNodeTo(){
        return  nodeTo;
    }
    
    public void SetIsVisited(bool _isVisited) {
        isVisited = _isVisited;
    }

    public bool GetIsVisited() { 
        return isVisited;
    }

    public void SetPeso(float _peso){
        peso = _peso;
    }

    public float GetPeso()
    {
        return peso;
    }
}
