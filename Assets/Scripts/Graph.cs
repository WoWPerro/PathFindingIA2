using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Graph
{
    public List<Node> nodes;
    private Queue<Node> NodesToCheck;
    private List<Node> NodesToCheckDjkstras;

    Node root;
    Node end;
    bool Finished = false;


    public Graph(List<Node> _nodes)
    {
        this.nodes = _nodes;
        NodesToCheck = new Queue<Node>();
    }

    public Graph()
    {
        NodesToCheck = new Queue<Node>();
    }

    public void SetNodes(List<Node> _nodes)
    {
        nodes = _nodes;
    }

    public List<Node> GetNodes()
    {
        return nodes;
    }

    public void SetRoot(ref Node _root)
    {
        root = _root;
    }

    public Node GetRoot()
    {
        return root;
    }

    public void BFS()
    {
        foreach (Edge e in root.GetEdges())
        {
            e.SetIsVisited(true);
            if (e.GetNodeTo() != root)
            {
                NodesToCheck.Enqueue(e.GetNodeTo());
            }
            if (e.GetNodeFrom() != root)
            {
                NodesToCheck.Enqueue(e.GetNodeFrom());
            }
        }

        while (NodesToCheck.Count > 0)
        {
            BFS2(NodesToCheck.First());
        }

    }

    private void BFS2(Node n)
    {
        foreach (Edge e in n.GetEdges())
        {
            e.SetIsVisited(true);
            if (e.GetNodeTo() != n)
            {
                NodesToCheck.Enqueue(e.GetNodeTo());
            }
            if (e.GetNodeFrom() != n)
            {
                NodesToCheck.Enqueue(e.GetNodeFrom());
            }
        }
        NodesToCheck.Dequeue();
    }

    //List<Node>  newBFS()
    //{
    //    Vector3Int edgecost;
    //    foreach (Edge e in root.GetEdges())
    //    {
    //       // edgecost = e.GetPeso();
    //        e.SetIsVisited(true);
    //        if (e.GetNodeTo() != root)
    //        {
    //            NodesToCheck.Enqueue(e.GetNodeTo());
    //        }
    //        if (e.GetNodeFrom() != root)
    //        {
    //            NodesToCheck.Enqueue(e.GetNodeFrom());
    //        }
    //    }

    //    while (NodesToCheck.Count > 0)
    //    {
    //        BFS2(NodesToCheck.First());
    //    }

    //}

    void Djkstras(Node startNode, Node end)
    {
        startNode.SetValue(0);
        foreach (Edge e in root.GetEdges())
        {
            e.SetIsVisited(true);
            if (e.GetNodeTo() != root)
            {
                e.GetNodeTo().SetValue(startNode.GetValue() + e.GetPeso());
                e.GetNodeTo().SetCorrectEdge(e);
                NodesToCheckDjkstras.Add(e.GetNodeTo());
            }
            if (e.GetNodeFrom() != root)
            {
                e.GetNodeFrom().SetValue(startNode.GetValue() + e.GetPeso());
                e.GetNodeFrom().SetCorrectEdge(e);
                NodesToCheckDjkstras.Add(e.GetNodeFrom());
            }
        }

        while (NodesToCheckDjkstras.Count > 0)
        {
            Djkstras2(GetLowestNode());
        }

    }

    void Djkstras2(Node n)
    {
        foreach (Edge e in n.GetEdges())
        {
            
            if(!e.GetIsVisited())
            {
                if (e.GetNodeTo() != n)
                {
                    if(e.GetNodeTo().GetValue() == -1)
                    {
                        e.GetNodeTo().SetValue(n.GetValue() + e.GetPeso());
                        e.GetNodeTo().SetCorrectEdge(e);
                        NodesToCheckDjkstras.Add(e.GetNodeTo());
                    }
                    else
                    {
                        if(e.GetNodeTo().GetValue() > n.GetValue() + e.GetPeso())
                        {
                            e.GetNodeTo().SetValue(n.GetValue() + e.GetPeso());
                            e.GetNodeTo().SetCorrectEdge(e);
                            NodesToCheckDjkstras.Add(e.GetNodeTo());
                        } //Else significa que el valor actual del nodo, es menor al que estamos revisando
                    }
                    
                }
                if (e.GetNodeFrom() != n)
                {
                    if(e.GetNodeFrom().GetValue() == -1)
                    {
                        e.GetNodeFrom().SetValue(n.GetValue() + e.GetNodeFrom().GetValue());
                        e.GetNodeFrom().SetCorrectEdge(e);
                        NodesToCheckDjkstras.Add(e.GetNodeFrom());
                    }
                    else
                    {
                        if (e.GetNodeFrom().GetValue() > n.GetValue() + e.GetPeso())
                        {
                            e.GetNodeFrom().SetValue(n.GetValue() + e.GetPeso());
                            e.GetNodeFrom().SetCorrectEdge(e);
                            NodesToCheckDjkstras.Add(e.GetNodeTo());
                        } //Else significa que el valor actual del nodo, es menor al que estamos revisando
                    }
                    
                }
                e.SetIsVisited(true);
            }
        }
        NodesToCheckDjkstras.Remove(n);
    }

    void SetupDkstras()
    {
        foreach(Node n in nodes)
        {
            n.SetValue(-1);
        }
    }

    private Node GetLowestNode()
    {
        float min = NodesToCheckDjkstras[0].GetValue();
        Node nodeToReturn = NodesToCheckDjkstras[0];
        for (int i = 0; i < NodesToCheckDjkstras.Count; i++)
        {
            if(min > NodesToCheckDjkstras[i].GetValue())
            {
                min = NodesToCheckDjkstras[i].GetValue();
                nodeToReturn = NodesToCheckDjkstras[i];
            }
        }
        return nodeToReturn;
    }

    public void Add(Node n)
    {
        nodes.Add(n);
    }

    void Astar(Node startNode, Node end)
    {
        startNode.SetValue(0);
        foreach (Edge e in root.GetEdges()) //Loopea por los Edges de Root
        {
            e.SetIsVisited(true);
            if (e.GetNodeTo() != root) //Revisar que a donde nos movamos no sea un loop
            {
                AddNodeToCheckAstar(e, e.GetNodeTo(), root);
            }
            if (e.GetNodeFrom() != root) //Revisar que a donde nos movamos no sea un loop
            {
                AddNodeToCheckAstar(e, e.GetNodeFrom(), root);
            }
        }

        while (NodesToCheckDjkstras.Count > 0) //Loop principal, hasta que no este vacía la lista o no encontremos el final, no acaba
        {
            if (Finished)
            {
                return;
            }
            Astar2(GetLowestNode());
        }

    }

    void Astar2(Node n)
    {
        foreach (Edge e in n.GetEdges())
        {

            if (!e.GetIsVisited()) //Sólo si no he visitado el edge es que lo reviso
            {
                if (e.GetNodeTo() != n) //Revisar que a donde nos movamos no sea un loop
                {
                    if (e.GetNodeTo().GetValue() == -1) //Revisar si el nodo ha sido visitado, para que sino, le sobreescribamos el valor
                    {
                        AddNodeToCheckAstar(e, e.GetNodeTo(), n);
                    }
                    else //Revisar si el nodo ha sido visitado, para que si si, nos quedemos con el menor valor
                    {
                        if (e.GetNodeTo().GetValue() > n.GetValue() + e.GetPeso() + e.GetNodeTo().GetManhattanDistance()) //Formula de A*
                        {
                            AddNodeToCheckAstar(e, e.GetNodeTo(), n);
                        } //Else significa que el valor actual del nodo, es menor al que estamos revisando
                    }

                }
                if (e.GetNodeFrom() != n) //Revisar que a donde nos movamos no sea un loop
                {
                    if (e.GetNodeFrom().GetValue() == -1) //Revisar si el nodo ha sido visitado, para que sino, le sobreescribamos el valor
                    {
                        AddNodeToCheckAstar(e, e.GetNodeFrom(), n);
                    }
                    else //Revisar si el nodo ha sido visitado, para que si si, nos quedemos con el menor valor
                    {
                        if (e.GetNodeFrom().GetValue() > n.GetValue() + e.GetPeso())
                        {
                            AddNodeToCheckAstar(e, e.GetNodeFrom(), n);
                        } //Else significa que el valor actual del nodo, es menor al que estamos revisando
                    }

                }
                e.SetIsVisited(true);
            }
        }
        NodesToCheckDjkstras.Remove(n);
    }

    /// <summary>
    /// Es una función que agrega los nodos a visitar en el NodesToCheckDjkstras, Le pone su valor al nodo al que nos vamos a mover y le pone su correctEdge
    /// <param name="e">Edge por el que nos estamos moviendo</param>
    /// <param name="nT">Nodo al que nos vamos a mover</param>
    /// <param name="nF">Nodo desde el que nos movimos</param>
    /// </summary>
    void AddNodeToCheckAstar(Edge e, Node nT, Node nF)
    {
        nT.SetValue(nF.GetValue() + e.GetPeso() + nT.GetManhattanDistance());
        nT.SetCorrectEdge(e);
        NodesToCheckDjkstras.Add(nT);
        if (nT == end)
        {
            Finished = true;
        }
    }

}
