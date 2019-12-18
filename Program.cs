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
			BruteSalesman brute = new BruteSalesman();
			GreedySalesman greedy = new GreedySalesman();

			//double[,] testMatrix1 = matrix.RandomCost(3, 100);
			//double[,] testMatrix2 = matrix.EuclideanCost(4, 100);
			//double[,] testMatrix3 = matrix.CircularCost(4, 100);

			//graph.PrintMatrix(testMatrix3, 10);
			//brute.BruteForce(testMatrix2);
			//brute.BruteCorrectness(testMatrix3);
			//greedy.GreedyCorrectness(testMatrix2);

			//brute.BruteTest("Pretest1.txt");
			//greedy.GreedyTest("GreedyPretestDouble.txt");
			greedy.HeuristicTest("HeuristicTest2.txt");
		}
	}
}
