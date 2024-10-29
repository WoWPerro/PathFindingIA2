using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private float value;
    private int ID;
    private List<Edge> Edges;

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



}
