using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	class GreedySalesman
	{
		Graph graph = new Graph();
		static Stopwatch stopwatch = new Stopwatch();
		static double leastCost = 9999999999;
		static double[,] costMatrix;

		int nodes;
		Stack<Int32> myStack;
		List<Int32> bestTour;
		int cost;

		public GreedySalesman()
		{
			myStack = new Stack<int>();
			bestTour = new List<int>();
		}

		public int[] Greedy(int[,] matrix)
		{
			nodes = matrix.GetLength(0);
			int[] visited = new int[nodes];
			visited[0] = 1;
			myStack.Push(1);
		}
	}
}
