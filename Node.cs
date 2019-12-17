using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	public class Node
	{
		public int x;
		public int y;
		public int Vertex;
		public List<Edge> Edges = new List<Edge>();

		public Node(int vertex)
		{
			Vertex = vertex;
		}

		public Node AddEdge(Node child, int weight)
		{
			Edges.Add(new Edge { Parent = this, Child = child, Weight = weight });

			if(!child.Edges.Exists(a => a.Parent == child && a.Child == this))
			{
				child.AddEdge(this, weight);
			}
			return this;
		}
	}
}
