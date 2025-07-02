using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ForStady.Structures
{
    internal class MyGraph
    {
        private Dictionary<MyGraphNode, List<MyGraphNode>> _adjacencyList;
        public MyGraph()
        {
            _adjacencyList = new Dictionary<MyGraphNode, List<MyGraphNode>> ();
        }
        public void AddVertex(MyGraphNode newNode)
        {
            if (!_adjacencyList.ContainsKey(newNode))
            {
                _adjacencyList[newNode] = new List<MyGraphNode>();
            }
            else
            {
                throw new Exception("Graph already conteins this vertex");
            }
        }
        public void AddEdge(MyGraphNode firstNode, MyGraphNode secondNode)
        {
            if (!_adjacencyList.ContainsKey(firstNode))
            {
                AddVertex(firstNode);
            }
            if (!_adjacencyList.ContainsKey(secondNode))
            {
                AddVertex(secondNode);
            }
            _adjacencyList[firstNode].Add(secondNode);
        }
        public void PrintGraph()
        {
            foreach(var vertex in _adjacencyList)
            {
                vertex.Key.Print();
                foreach(var edge in vertex.Value)
                {
                    Console.Write("|---");
                    edge.Print();
                }
            }
        }

    }
}
