using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	//This class encompasses my brute force TSP algorithms

	class BruteSalesman
	{
		MatrixGen matrixGen = new MatrixGen();
		Graph graph = new Graph();
		//static Stopwatch stopwatch = new Stopwatch();
		public static int[] bestTour;
		static double leastCost = 9999999999;
		static double[,] costMatrix;
		
		public void BruteForce(double[,] matrix)
		{
			int length = matrix.GetLength(0);

			int[] currentPermutation = new int[length];

			for(int i = 0; i < length; i++)
			{
				currentPermutation[i] = i;
			}

			bestTour = (int[])currentPermutation.Clone();

			do
			{
				double pathCost = TravelCost(currentPermutation, matrix);

				if (pathCost < leastCost)
				{
					leastCost = pathCost;
					bestTour = (int[])currentPermutation.Clone();
				}
			} while (NextPerm(currentPermutation));

			
		}

		public double TravelCost(int[] path, double[,] matrix)
		{
			double cost = 0;

			for(int i = 1; i < matrix.GetLength(0); i++)
			{
				int begin = path[i - 1];
				int end = path[i];
				cost += matrix[begin, end];
			}

			int last = path[matrix.GetLength(0) - 1];
			int first = path[0];
			return cost + matrix[last, first];
		}

		public Boolean NextPerm(int[] sequence)
		{
			int first = getFirst(sequence);
			if(first == -1)
			{
				return false;
			}

			int toSwap = sequence.Length - 1;
			while(sequence[first] >= sequence[toSwap])
			{
				--toSwap;
			}
			swap(sequence, first++, toSwap--);
			toSwap = sequence.Length - 1;
			while (first < toSwap)
			{
				swap(sequence, first++, toSwap--);

			}
			return true;
		}

		public int getFirst(int[] sequence)
		{
			for(int i = sequence.Length - 2; i >= 0; --i)
			{
				if(sequence[i] < sequence[i + 1])
				{
					return i;
				}
			}
			return -1;
		}

		public void swap(int[] sequence, int i, int j)
		{
			int temp = sequence[i];
			sequence[i] = sequence[j];
			sequence[j] = temp;
		}

		public void BruteCorrectness(double[,] matrix)
		{
			var length = matrix.GetLength(0);
			var expectedCost = matrix[0, 1] * length;
			graph.PrintMatrix(matrix, length);
			BruteForce(matrix);
			Console.WriteLine("Expected optimal path cost: {0}", expectedCost);
			Console.WriteLine("Optimal path:", bestTour);
			foreach (int i in bestTour)
			{
				Console.Write("{0} ", i);
			}
			Console.Write("0");
			Console.WriteLine();
			Console.WriteLine("Optimal path cost: {0}", leastCost);
		}

		public void BruteTest(string resultFile)
		{
			string resultsFolderPath = "C:\\Users\\Adria\\School Stuff\\CSC482\\Lab8";
			int maxInput = 20;
			double numberOfTrials = 10;
			Stopwatch stopwatch = new Stopwatch();

			double nanoSecs = 0;
			Console.WriteLine("Input Size\tAvg Time (ns)");

			for(int i = 1; i <= maxInput; i++)
			{
				for(int trial = 1; trial <= numberOfTrials; trial++)
				{
					double[,] testMatrix = matrixGen.RandomCost(i, 100);

					stopwatch.Restart();
					BruteForce(testMatrix);
					stopwatch.Stop();
					nanoSecs += stopwatch.Elapsed.TotalMilliseconds * 1000000;
				}
				double averageTrialTime = nanoSecs / numberOfTrials;
				Console.WriteLine("{0, -10}\t{1, 16}", i, averageTrialTime);

				using (StreamWriter outputFile = new StreamWriter(Path.Combine(resultsFolderPath, resultFile), true))
				{
					outputFile.WriteLine("{0, -10}\t{1, 16}", i, averageTrialTime);
				}
			}
		}
	}
}
