using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	class Program
	{
		static void Main(string[] args)
		{
			MatrixGen matrix = new MatrixGen();
			Graph graph = new Graph();

			int[,] testMatrix = matrix.RandomCost(5, 15);

			graph.PrintMatrix(testMatrix, 5);
		}
	}
}
