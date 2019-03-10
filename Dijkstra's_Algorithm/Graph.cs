using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Dijkstra_s_Algorithm
{
    class Graph
    {
        public Dictionary<string, Node> Nodes { get; private set; }
        public List<Edge> Edges { get; private set; }
        public Dictionary<Node, List<Edge>> AdjacencyList { get; private set; }

        // Constructor
        public Graph()
        {
            this.Nodes = new Dictionary<string, Node>();
            this.Edges = new List<Edge>();
            this.AdjacencyList = new Dictionary<Node, List<Edge>>();
        }

        public Node AddNode(string name, int x, int y)
        {
            Node n = new Node(name, x, y);
            if(this.Nodes.ContainsKey(name))
            {
                Console.WriteLine("같은 이름의 지역이 이미 존재합니다.");
                return null;
            }
            else
            {
                this.Nodes.Add(n.Name, n);
                this.AdjacencyList.Add(n, n.AdjacentEdge);
                return n;
            }
        }

        public Edge AddEdge(string u_name, string v_name, int weight)
        {
            if(this.Nodes.ContainsKey(u_name) && this.Nodes.ContainsKey(v_name))
            {
                Edge e = new Edge(this.Nodes[u_name], this.Nodes[v_name], weight);
                if (this.Edges.Contains(e))
                {
                    Console.WriteLine("해당 지역들은 이미 연결되어 있습니다.");
                    return null;
                }
                else
                {
                    this.Edges.Add(e);
                    return e;
                }
            }
            else
            {
                return null;
            }
        }

        public Node Dijkstra(string s, string e)
        {
            if (!this.Nodes.ContainsKey(s))
            {
                Console.WriteLine("출발지가 존재하지 않습니다.");
                return null;
            }
            else if (!this.Nodes.ContainsKey(e))
            {
                Console.WriteLine("도착지가 존재하지 않습니다.");
                return null;
            }
            else
            {
                foreach(Node n in this.Nodes.Values)
                {
                    n.Value = int.MaxValue;
                    n.ShortestPath = new List<Node>();
                }

                Node start = this.Nodes[s];
                Node end = this.Nodes[e];
                start.Value = 0;
                start.ShortestPath.Add(start);
                
                List<Node> candidateList = new List<Node>();
                candidateList.Add(start);

                while(candidateList.Count > 0)
                {
                    Node u = candidateList.First();
                    candidateList.Remove(u);

                    foreach (Edge edge in u.AdjacentEdge )
                    {
                        Node v;
                        if (edge.U == u)
                        {
                            v = edge.V;
                        }
                        else
                        {
                            v = edge.U;
                        }

                        if(v.Value > u.Value + edge.Weight)
                        {
                            v.Value = u.Value + edge.Weight;
                            v.ShortestPath = u.ShortestPath.ToList();
                            v.ShortestPath.Add(v);
                            candidateList.Add(v);
                        }
                    }

                    candidateList.Sort();
                }

                return end;
            }
        }
    }
}
