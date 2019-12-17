using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	public class Graph
	{
		public Node Root;
		public List<Node> AllNodes = new List<Node>();

		public Node CreateRoot(int vertex)
		{
			Root = CreateNode(vertex);
			return Root;
		}

		public Node CreateNode(int vertex)
		{
			var v = new Node(vertex);
			AllNodes.Add(v);
			return v;
		}

		public int?[,] CreateAdjMatrix()
		{
			int?[,] adjMatrix = new int?[AllNodes.Count, AllNodes.Count];

			for(int i = 0; i < AllNodes.Count; i++)
			{
				Node n1 = AllNodes[i];

				for(int j = 0; j < AllNodes.Count; j++)
				{
					Node n2 = AllNodes[j];

					var edge = n1.Edges.FirstOrDefault(a => a.Child == n2);

					if(edge != null)
					{
						adjMatrix[i, j] = edge.Weight;
					}
				}
			}
			return adjMatrix;
		}

		public void PrintMatrix(double[,] matrix, int Count)
        {
            Console.Write("       ");
			for (int i = 0; i < Count; i++)
			{
				Console.Write(string.Format("{0, -12} ", i));
            }

            Console.WriteLine();

            for (int i = 0; i < Count; i++)
            {
                Console.Write(string.Format("{0} | [ ", i));

                for (int j = 0; j < Count; j++)
                {

                    Console.Write(string.Format("{0, -10}, ", matrix[i, j]));

                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
        }
	}
}
