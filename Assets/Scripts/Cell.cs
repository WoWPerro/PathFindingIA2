using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private float value;
    private int ID;
    private List<Edge> Edges;
    private Edge CorrectEdge;
    private float ManhattanDistance;


    public Node (float _value, int _ID, List<Edge> _Edges) 
    {
        value = _value;
        ID = _ID;
        Edges = _Edges;
    }

    public Node(float _value, int _ID)
    {
        value = _value;
        ID = _ID;
    }

    public float GetValue()
    {
        return value;
    }

    public void SetValue(float _value)
    {
        value = _value;
    }

    public int GetID()
    {
        return ID;
    }

    public void SetID(int _id )
    {
        ID = _id;
    }

    public List<Edge> GetEdges()
    {

    return Edges; }

    public  void SetEdges(List<Edge> _edges)
    {
        Edges = _edges;
    }

    public void SetCorrectEdge(Edge _correctEdge)
    {
        CorrectEdge = _correctEdge;
    }

    public Edge GetCorrectEdge()
    {
        return CorrectEdge;
    }

    public void SetManhattanDistance(float _manhattanDistance)
    {
        ManhattanDistance = _manhattanDistance;
    }

    public float GetManhattanDistance()
    {
        return ManhattanDistance;
    }

}
