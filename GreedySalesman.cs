using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	public class GreedySalesman
	{
		Graph graph = new Graph();
		MatrixGen matrixGen = new MatrixGen();
		BruteSalesman brute = new BruteSalesman();
		static Stopwatch stopwatch = new Stopwatch();
		static double leastCost = 9999999999;
		//static double[,] costMatrix;

		int nodes;
		Stack<int> myStack;
		List<double> bestTour;
		//int cost;
		private double minimum = leastCost;

		public GreedySalesman()
		{
			myStack = new Stack<int>();
			bestTour = new List<double>();
		}

		public double[] Greedy(double[,] matrix)
		{
			nodes = matrix.GetLength(1);
			int[] visited = new int[nodes];
			visited[0] = 1;
			myStack.Push(1);
			int el, dst = 0, i;
			
			Boolean isMinimum = false;

			while(myStack.Count() != 0)
			{
				el = myStack.Peek();
				i = 0;
				minimum = leastCost;
				
				while(i < nodes)
				{
					if(matrix[el, i] > 1 && visited[i] == 0)
					{
						if(minimum > matrix[el, i])
						{
							minimum = matrix[el, i];
							dst = i;
							isMinimum = true;
						}
					}
					i++;
				}
				if (isMinimum)
				{
					visited[dst] = 1;
					myStack.Push(dst);
					bestTour.Add(dst - 1);
					isMinimum = false;
					continue;
				}
				myStack.Pop();
			}

			double[] pathArray = new double[bestTour.Count()];

			for(int x = 0; x < bestTour.Count(); x++)
			{
				if(bestTour[x] != null)
				{
					pathArray[x] = bestTour[x];
				}
			}
			
			return pathArray;
		}

		public double GreedyTravelCost(double[] path, double[,] matrix)
		{
			double cost = 0;

			for(int i = 1; i < path.Length; i++)
			{
				double begin = path[i - 1];
				double end = path[i];
				cost += matrix[(int)begin, (int)end];
			}

			int temp = 0;
			if(path.Length >= 1)
			{
				temp = path.Length - 1;
			}
			double last = path[temp];
			double first = path[0];
			return cost + matrix[(int)last, (int)first];
		}

		public void GreedyCorrectness(double[,] matrix)
		{
			var length = matrix.GetLength(0);
			var expectedCost = matrix[0, 1] * length;
			graph.PrintMatrix(matrix, length);
			double[] resultArray = Greedy(matrix);
			Console.WriteLine("Expected optimal path cost: {0}", expectedCost);
			var trueCost = GreedyTravelCost(resultArray, matrix);
			Console.WriteLine("Optimal path:");
			foreach (int i in resultArray)
			{
				Console.Write("{0} ", i);
			}
			Console.Write("0");
			Console.WriteLine();
			Console.WriteLine("Optimal path cost: {0}", trueCost);
		}

		public void GreedyTest(string resultFile)
		{
			string resultsFolderPath = "C:\\Users\\Adria\\School Stuff\\CSC482\\Lab8";
			int maxInput = Convert.ToInt32(Math.Pow(2, 15));
			double numberOfTrials = 10;
			Stopwatch stopwatch = new Stopwatch();

			double nanoSecs = 0;
			Console.WriteLine("Input Size\tAvg Time (ns)");

			for (int i = 50; i <= maxInput; i+=i)
			{
				for (int trial = 1; trial <= numberOfTrials; trial++)
				{
					double[,] testMatrix = matrixGen.RandomCost(i, 100);

					stopwatch.Restart();
					Greedy(testMatrix);
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

		public void HeuristicTest(string resultFile)
		{
			string resultsFolderPath = "C:\\Users\\Adria\\School Stuff\\CSC482\\Lab8";
			Console.WriteLine("Input Size\tExpected Cost\tAvgGreedCost\tAvg SQR (10 Trials)");
			double trialCost = 0;
			double greedyCostTotal = 0;
			int numberOfTrials = 10;
			for(int i = 4; i <= 11; i++)
			{
				for(int trial = 1; trial <= numberOfTrials; trial++)
				{
					double[,] testMatrix = matrixGen.EuclideanCost(i, 100);
					double[] greedyArray = Greedy(testMatrix);
					double currentCost = GreedyTravelCost(greedyArray, testMatrix);
					brute.BruteForce(testMatrix);
					trialCost = brute.TravelCost(BruteSalesman.bestTour, testMatrix);

					
					//Console.WriteLine(currentCost);
					greedyCostTotal += currentCost;
				}

				double averageGreedyCost = greedyCostTotal / numberOfTrials;
				double averageSQR = averageGreedyCost / trialCost;
				Console.WriteLine("{0, -10}\t{1,10}\t{2,10}\t{3,10}", i,trialCost, averageGreedyCost, averageSQR);

				using (StreamWriter outputFile = new StreamWriter(Path.Combine(resultsFolderPath, resultFile), true))
				{
					outputFile.WriteLine("{0, -10}\t{1,10}\t{2,10}\t{3,10}", i, trialCost, averageGreedyCost, averageSQR);
				}
			}
		}
	}
}
