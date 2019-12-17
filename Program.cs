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

			//int[,] testMatrix = matrix.RandomCost(5, 15);
			double[,] testMatrix2 = matrix.EuclideanCost(5, 100);
			double[,] testMatrix3 = matrix.CircularCost(10, 100);
		
			//graph.PrintMatrix(testMatrix3, 10);
			//brute.BruteForce(testMatrix3);
			brute.BruteCorrectness(testMatrix3);
		}
	}
}
