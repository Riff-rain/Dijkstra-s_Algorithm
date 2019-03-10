using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_Algorithm
{
    class Edge
    {
        public Node U { get; private set; }
        public Node V { get; private set; }
        public int Weight;

        // Constructor
        public Edge(Node u, Node v, int weight)
        {
            this.U = u;
            u.AdjacentEdge.Add(this);
            this.V = v;
            v.AdjacentEdge.Add(this);
            this.Weight = weight;

        }
    }
}
