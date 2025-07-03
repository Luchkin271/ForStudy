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
            _adjacencyList = new Dictionary<MyGraphNode, List<MyGraphNode>>();
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
            foreach (var vertex in _adjacencyList)
            {
                vertex.Key.Print();
                foreach (var edge in vertex.Value)
                {
                    Console.Write("|---");
                    edge.Print();
                }
            }
        }
        public List<MyGraphNode> FindPathBFS(MyGraphNode start, MyGraphNode goal)
        {
            var queue = new Queue<MyGraphNode>();
            var visited = new Dictionary<MyGraphNode, MyGraphNode>();
            queue.Enqueue(start);
            visited[start] = null;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == goal)
                {
                    return ReconstructPath(visited, goal);
                }
                foreach (var neighbor in _adjacencyList[current])
                {
                    if (!visited.ContainsKey(neighbor))
                    {
                        visited[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return null;
        }
        private List<MyGraphNode> ReconstructPath(Dictionary<MyGraphNode, MyGraphNode> visited, MyGraphNode goal)
        {
            var path = new List<MyGraphNode>();
            var current = goal;
            while (current != null)
            {
                path.Add(current);
                current = visited[current];
            }
            path.Reverse();
            return path;
        }
    }
}
