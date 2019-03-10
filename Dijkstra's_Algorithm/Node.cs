using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_Algorithm
{
    class Node :IComparable
    {
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public List<Edge> AdjacentEdge;
        public int Value;
        public List<Node> ShortestPath;

        // Constructor
        public Node(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.AdjacentEdge = new List<Edge>();
            this.Value = int.MaxValue;
            this.ShortestPath = new List<Node>();
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(((Node)obj).Value);
        }
    }
}
